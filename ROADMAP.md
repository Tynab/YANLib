# YANLib roadmap and open decisions

This page records the design decisions found during the 8.3.3 review (Areas A-E), while the 8.4.0 additions were built (G1-G4) and when CI was added (F). Each entry lists the context, the options and a recommendation. Nothing here is implemented unless the entry says it was chosen for, or done in, 8.4.0.

## Owner decisions (November 2026)

- Next release: **8.4.0**.
- Breaking changes stay out of 8.x; they are collected under *Planned for 9.0* below.
- New, non-breaking API for 8.4.0: `Parse` with `IFormatProvider`, `Random.NextChar(char min, char max)`, `YANProcess` overloads with an `entireProcessTree` choice and with cancellation/timeout, and public `YANTask.WaitAnyWithConditions` / `WhenAnyWithConditions` (cancellation throws `OperationCanceledException`).
- Internal improvements for 8.4.0: compiled property accessors in `YANObject`, `Snowflake` `SpinWait` and epoch-range validation, exact `Round` beyond 15 digits for tiny doubles, and no `[DebuggerHidden]`/`[DebuggerStepThrough]` in `YANLib.Implementation`.

## Chosen for 8.4.0

### Culture dependency of Parse and Convert

*Area:* Parse / collections

**Chosen for 8.4.0: additive IFormatProvider overloads, CurrentCulture stays the default (option 2). Invariant default is a 9.0 item. Done in 8.4.0 (ccdf3e9, 517386d): `ParseWith<T>(this object?, IFormatProvider?)` (rules of `Parse<T>()`), `ParseWith<T>(this object?, IFormatProvider?, object? defaultValue, IEnumerable<string?>? / params string?[]? format) where T : unmanaged`, and `ParsesWith<T>` for the `IEnumerable<object?>` and non-generic `IEnumerable` forms of both (YANUnmanaged.md, Culture). They have a new name because a `Parse<T>(object?, IFormatProvider)` overload would silently rebind `x.Parse<int>(CultureInfo.InvariantCulture)` and `x.Parse<int>(null)`, which pass a defaultValue today; a scratch consumer (C# 12 to 14) binds all 148 existing Parse/Parses call shapes as before. A `null` provider is the existing behaviour. Exact DateTime formats stay on InvariantCulture with any provider, as in `Parse`. The dictionary/lookup forms and the YANEnumerable conversions have no provider form.**

Strings are parsed with CultureInfo.CurrentCulture, as Convert.ChangeType did. Under de-DE and vi-VN, "1.5".Parse<double>() == 15 and 1.5.Parse<string>() == "1,5". The equivalence table shows the same culture behaviour old and new.

Options:

- Use InvariantCulture by default (breaking)
- Add IFormatProvider overloads (additive; check CS0121 against the params string?[] format overload with a scratch consumer)
- Keep and document (done in YANUnmanaged.md)

Recommendation: Add IFormatProvider overloads in a minor release (or one taking ParseOptions to avoid ambiguity with params), keep CurrentCulture as the default, and consider an invariant default for 9.0.

### Compiled accessors for IsNullDefault / AllProperties* / Copy (spec-listed)

*Area:* YANObject / YANExpression

**Chosen for 8.4.0: compiled getters/setters cached per type, getter exceptions still wrapped in TargetInvocationException (option 2). Done in 8.4.0 (9b86e8e, 5ffcf25): the property checks (IsNullDefault, IsNotNullDefault, AllProperties*/AnyProperties*, every form) and Copy read and write each property through a DynamicMethod accessor cached per Type and compiled on the accessor's second call (its first call stays the reflection call, as .NET 8 reflection's own first call is interpreted, so the results, the getter/setter calls and the exception type, message, HResult and InnerException are unchanged; from the second call the TargetInvocationException's Source, TargetSite and stack traces point into YANLib.Implementation instead of the reflection invoker, see YANObject.md, Changes since 8.3.3); getter, setter and constructor exceptions surface as TargetInvocationException wrapping the thrown instance; pointer, function pointer and ref-return properties, and every property under the Switch.System.Reflection.ForceInterpretedInvoke switch (as set when the accessor would compile; reflection keeps the value it read first, so clearing the switch at run time after reflection has read it as set is not mirrored, see YANObject.md, Performance Considerations), stay on reflection; ChangeTimeZoneAllProperty is unchanged. Measured (Release, Stopwatch): IsNullDefault on 6 properties 199 -> 99 ns, Copy of 10 properties 597 -> 89 ns; the second call of a new type costs about 0.3 ms (6-property IsNullDefault) to 0.9 ms (10-property Copy) more for the compilation (YANObject.md, Performance Considerations). No BenchmarkDotNet suite was added.**

Every property is read with PropertyInfo.GetValue on every call (the ~30 ns reflection invoke dominates; IsNullDefault on 6 properties is ~200+ ns). An earlier prototype with Expression-compiled getters/setters per type was 2-10x faster, but getter exceptions would surface raw instead of wrapped in TargetInvocationException, which the docs now describe.

Options:

- Keep reflection (the state before 8.4.0; exception type documented as TargetInvocationException)
- Compiled getters/setters cached per Type, and wrap getter exceptions in TargetInvocationException to keep the contract
- Compiled accessors with raw exceptions, documented as a behaviour change in a minor release

Recommendation: Option 2. Same observable behaviour with a large speed-up. Do it in a separate change with a BenchmarkDotNet suite.

### [DebuggerHidden]/[DebuggerStepThrough] on public members

*Area:* Packaging / docs / tooling

**Chosen for 8.4.0: remove the attributes from YANLib.Implementation only (option 2).**

**Done in 8.4.0 (2f3a038): the 543 [DebuggerHidden] and 543 [DebuggerStepThrough] attributes of YANLib.Implementation were removed; the thin public facade keeps them, so a step from user code goes straight into the implementation, whose code can be stepped through.**

Before 8.4.0 there were 1160 occurrences of each in lib/*.cs. Consumers could not step into library frames, and exceptions surfaced at the call site.

Options:

- Keep
- Remove from the implementation only
- Remove everywhere

Recommendation: Option 2: keep the thin facade hidden but let the debugger step into the implementation.

### Version bump and release notes

*Area:* Packaging / docs / tooling

**Chosen: 8.4.0. Done in 8.4.0 (08f47a0): Version 8.4.0, PackageReleaseNotes and CHANGELOG.md.**

Areas A-E added API and changed packaging (XML docs, no favicon content, validation). Until 08f47a0 the version was still 8.3.3 and PackageReleaseNotes described 8.3.3. The package validation baseline stays 8.3.3.

Options:

- 8.4.0 (new API, packaging fixes)
- 8.3.4 (if only fixes are counted)
- Leave to the owner at release time

Recommendation: Option 1 (8.4.0), chosen by the owner and done, with PackageReleaseNotes updated at the bump. The validation baseline can stay at 8.3.3 or move to the last published version.

### Make WaitAnyWithConditions / WhenAnyWithConditions (and AsyncEnumerableEmpty) public

*Area:* YANTask / YANProcess / YANText / Snowflake

**Chosen for 8.4.0: make WaitAnyWithConditions / WhenAnyWithConditions public (AsyncEnumerableEmpty stays internal).**

**Done in 8.4.0 (6ffea4f, documented in 1aafb53): both are public facade methods with the internal signatures; package validation passes. A null predicate throws ArgumentNullException since 3c2ab80 (see "Null predicate in the YANTask methods" below).**

In 8.3.3 they were internal in the facade although YANTask.md documented them as public; the 8.3.3 review first marked them internal in the docs, and tests reached them via InternalsVisibleTo.

Options:

- Keep them internal (the state before 8.4.0); docs say so
- Make them public in a minor release (an addition, package validation passes) after N5/N6 and the cancellation semantics are settled
- Delete them

Recommendation: Keep internal until N5/N6 and the cancellation semantics below are decided, then make them public in a minor release.

### Streaming variants: cancellation ends the enumeration quietly vs throws

*Area:* YANTask / YANProcess / YANText / Snowflake

**Chosen for 8.4.0: throw OperationCanceledException in every cancellation case, as the .NET convention (option 2), together with making the methods public.**

**Done in 8.4.0 (6ffea4f): a token already canceled when the enumeration starts (also for a null or empty collection), a WithCancellation token, a cancellation while waiting and one while the consumer handles an item all throw OperationCanceledException; continuations are still removed.**

Before 6ffea4f, the review had implemented a quiet end in every case: already cancelled, WithCancellation, while waiting, while the consumer handles an item. That matched the XML doc and the pre-cancel tests; 8.3.3 threw only mid-enumeration. Only internal callers existed then.

Options:

- Keep the quiet end (the state before 6ffea4f)
- Throw OperationCanceledException in every case (the .NET convention, e.g. ChannelReader.ReadAllAsync), changing the pre-cancel tests
- Add a parameter that chooses

Recommendation: If the methods become public, switch to throwing OperationCanceledException in all cases before shipping; otherwise keep the current behaviour.

### N7: YANProcess has no timeout/cancellation; the facade methods are redundant async/await wrappers

*Area:* YANTask / YANProcess / YANText / Snowflake

**Chosen for 8.4.0: add CancellationToken / timeout overloads (option 2). Done in 8.4.0 (be44ee9, d61c34e): `KillAllProcessesByName(this string?, CancellationToken)` and `KillAllProcessesByNames<TNames>(this TNames?, CancellationToken)`, plus the token parameter of the entireProcessTree overloads below. A timeout is the token of `new CancellationTokenSource(TimeSpan)`: TimeSpan overloads would make a `default` argument ambiguous (CS0121). The facade async/await wrappers are unchanged. Source break to list in the 8.4.0 release notes: with more than one overload, the `KillAllProcessesByName` method group has no natural type, so `var f = YANProcess.KillAllProcessesByName;` (which compiled against 8.3.3) now fails with CS8917 and needs an explicit delegate type (`Func<string?, Task>`); explicitly typed delegates and `Select(YANProcess.KillAllProcessesByName)` still bind to the old overload.**

WaitForExitAsync can wait indefinitely for a process that ignores SIGKILL (e.g. D state); the facade does `async Task X() => await XImplement()`.

Options:

- Keep
- Add overloads with CancellationToken / TimeSpan timeout (non-breaking additions)
- Drop async/await in the facade and return the task directly (no signature change; slightly different stack traces)

Recommendation: Add CancellationToken overloads and return the implementation task directly.

### S7: WaitForNextMillisecond busy-spins at 100% CPU while holding the lock

*Area:* YANTask / YANProcess / YANText / Snowflake

**Chosen for 8.4.0: SpinWait.SpinOnce() in the wait loop.**

**Done in 8.4.0 (0984360): WaitForNextMillisecond spins with SpinWait.SpinOnce(); the IDs are unchanged. Measured with BitAllocationStrategy.MoreDistributed (16,000 IDs): about 0.1 s of CPU instead of 2.0 s, and about 2.2 s instead of 2.0 s of wall time (see "SpinWait.SpinOnce() vs SpinOnce(-1)" below).**

The 8.3.3 review did not change it (spec: thread-safety fine, locking untouched).

Options:

- Keep
- SpinWait.SpinOnce() in the loop (same latency, less CPU burn)
- Sleep until the next millisecond (Thread.Sleep(1); coarse on Windows)

Recommendation: SpinWait.SpinOnce(); low risk, no output change.

### S8: timestampEpoch is not validated, so the 41-bit timestamp field can overflow or go negative

*Area:* YANTask / YANProcess / YANText / Snowflake

**Chosen for 8.4.0: NextId* throw ArgumentOutOfRangeException when now - epoch is negative or >= 2^41 (option 2; a behaviour change, listed in the release notes).**

**Done in 8.4.0 (65b0748): NextId, NextIdAlphabetic and NextIdAlphanumeric throw ArgumentOutOfRangeException (ParamName "timestampEpoch") before any state changes, so a failing call uses up no sequence number. Elapsed times of 2^40 to 2^41 - 1 ms still set the sign bit; Extract* reads them unsigned since 1f32140 (see "Timestamps in [2^40, 2^41) set the sign bit" below).**

The 8.3.3 review did not change it: negative IDs were made to encode safely, but an epoch far in the past could overflow into the sign bit.

Options:

- Keep
- Throw ArgumentOutOfRangeException in NextId when now - epoch is negative or >= 2^41
- Validate a fixed epoch in the constructor (API change)

Recommendation: Throw ArgumentOutOfRangeException in NextId* in the next major (behaviour change for callers relying on negative IDs).

### Kill(entireProcessTree: true) vs Kill() in YANProcess (corrected context)

*Area:* YANTask / YANProcess / YANText / Snowflake

**Chosen for 8.4.0: keep the tree kill as the default and add an opt-in entireProcessTree parameter/overload (option 3). Done in 8.4.0 (be44ee9): `KillAllProcessesByName(this string?, bool entireProcessTree, CancellationToken = default)` and `KillAllProcessesByNames<TNames>(this TNames?, bool entireProcessTree, CancellationToken = default) where TNames : IEnumerable<string?>`, generic so that `params` calls with only null/default arguments keep their binding; `false` uses Kill(), so a matching ancestor of the caller is killed on its own. The new same-name overloads remove the natural type of the `KillAllProcessesByName` method group: `var f = YANProcess.KillAllProcessesByName;` needs an explicit delegate type (`Func<string?, Task>`) since 8.4.0 (CS8917; see N7).**

KillAllProcessesByName(s) kills each matching process with Process.Kill(entireProcessTree: true), so every descendant is killed too, whatever its name (for example child processes of a matching shell). The earlier record wrongly said the caller dies when a matching process is its ancestor. In fact .NET refuses any tree that contains the calling process: the ancestor stays alive, nothing is killed through it, and the library still kills the other matches and then rethrows the first failure. I verified this with the new test KillAndDispose_AncestorOfCallingProcess_IsRefusedAndTheOthersAreStillKilled_Process; the two verifiers observed it on .NET 8.0.34. The calling process itself is skipped by id. So the caller is never killed, but a by-name call that matches an ancestor (for example a shell name) ends with InvalidOperationException. Switching to Kill() would stop killing unrelated descendants and would also stop the ancestor refusal: an ancestor with a matching name would then be killed on its own, without its tree.

Options:

- Keep Kill(entireProcessTree: true) as documented now (descendants die, ancestor tree refused with InvalidOperationException, caller never killed)
- Switch to Kill() (only the named processes; a matching ancestor would be killed itself and no InvalidOperationException), a behaviour change for callers relying on tree kills
- Add an opt-in overload or parameter (for example entireProcessTree: bool = true) and check overload resolution for CS0121 and silent rebinding
- Keep tree kills but skip ancestors of the caller explicitly (no InvalidOperationException), a behaviour change in which exceptions are thrown

Recommendation: Keep Kill(entireProcessTree: true) for this release, now correctly documented. If tree kills prove surprising, add an opt-in overload in a later minor version rather than changing the default.

### A public bounded NextChar

*Area:* YANMath / YANRandom

**Chosen for 8.4.0: typed NextChar(this Random, char min, char max).**

**Done in 8.4.0 (1512816): `Random.NextChar(char min, char max)` returns a char in [min, max). It removes the natural delegate type of the NextChar method group (CS8917; see "NextChar(char, char) removes the natural delegate type" below).**

Public NextChar(this Random) returns a-z only. Char bounds now work through GenerateRandom<char>(min, max) and GenerateRandom('a', 'f'). The other Next* methods take (object? min, object? max), and NextChar does not.

Options:

- Leave as is; GenerateRandom<char> covers bounds
- Add NextChar(this Random, object? min, object? max) to match the other Next* methods (random.NextChar() still binds to the parameterless one)
- Add a typed NextChar(this Random, char min, char max)

Recommendation: Add NextChar(this Random random, char min, char max) in a minor release. It is typed and unambiguous, and the internal NextCharImplement(random, min, max) already implements it.

### RoundDouble with more than 15 digits for values whose shortest text needs more than 28 decimal places

*Area:* YANMath / YANRandom

**Chosen for 8.4.0: digit-shift rounding (option b).**

**Done in 8.4.0 (2dbdbae, with 930c0ed for boxed decimal inputs): a double whose shortest text needs more than 28 decimal places is rounded by shifting its digits, so Round is exact at any number of digits: 1.9999999999999998e-13.Round(20, ToZero) returns 1.9999999E-13 and 1e-30.Round(30) returns 1E-30. Documented in YANMath.md (Precision, Rounding and Overflow) and the Round XML remarks, and pinned by Round_DoubleMoreThan28DecimalPlaces_RoundsExactlyOnShortestText_Math. Strings and boxed decimals keep the 28-places-first path (see the two entries under "Decisions recorded while building 8.4.0").**

The spec's recipe is Math.Round(ToDecimal(v), Math.Min(decimals, 28), mode). For |v| < ~1e-11 with 17 significant digits, ToDecimal first rounds v to 28 places, so the result could be one unit in the last requested place off. Example: before 2dbdbae, 1.9999999999999998e-13.Round(20, ToZero) returned 2E-13; the exact answer is 1.9999999E-13. 8.3.3 threw ArgumentOutOfRangeException for any digits above 15. The object path was already fixed, because it falls back to the double computation. RoundDouble could not use that fallback, because Math.Round(v, 15) returns 0 for these values. Until 2dbdbae the limit was documented and pinned by Round_DoubleMoreThan28DecimalPlaces_RoundsAt28PlacesFirst.

Options:

- (a) Keep the documented limit (the state before 2dbdbae).
- (b) Add digit-shift rounding, about 20 lines. Take the mantissa digits and exponent of the R text, build a decimal shifted by 10^places, decimal.Round to 0 places, and parse back as '<q>E-<places>'. Use it only when the direct conversion needs more than 28 places. Flip the pin test to 1.9999999e-13.
- (c) Throw ArgumentOutOfRangeException, as 8.3.3 did, when such a value is rounded to more than 15 digits.
- (d) Round such values to 15 digits with Math.Round. This is often worse: tiny values become 0.

Recommendation: (b) as a small follow-up, so the new 'more than 15 digits' feature is correct across its whole domain. Taken in 8.4.0 (see the status above).

## Planned for 9.0 (breaking)

These change public behaviour or signatures. The recommendations describe the 9.0 direction; 8.x keeps today's behaviour (documented in the wiki pages).

### Parse overload semantics disagree (floor vs default vs null; char)

*Area:* Parse / collections

"3.5".Parse<int>() = 3 (floors), "3.5".Parse<int>(-77) = -77, "3.5".Parse<int?>() = null. 5.Parse<char>() = '5' (through text) but 5.Parse<char>('#') = '\u0005' (Convert.ToChar). This is preserved exactly from 8.3.3 and documented in YANUnmanaged.md 'Conversion Rules'.

Options:

- Keep and document (current state)
- Unify on floor for every integer target and overload (breaking for defaultValue and nullable callers)
- Unify on 'a fraction is a failure' (breaking: "3.7".Parse<int>() becomes 0)
- Add an explicit option (e.g. rounding/fraction mode or an options overload), keeping today's defaults

Recommendation: Keep and document in 8.x. In the next major, unify on 'fraction = failure' unless a rounding mode is passed explicitly (option 4 + 3), with an [Obsolete] note one minor release earlier.

### Should PropertyExpression invoke methods at all? (spec-listed)

*Area:* YANObject / YANExpression

With B6, a name that matches no property but a public parameterless method builds a call (ToString, GetType, GetHashCode, or any user method with side effects). If the name is user-controlled (e.g. an API sort field), callers can make the app invoke arbitrary parameterless methods. The XML remarks now recommend validating with IsValidField first.

Options:

- Keep method invocation (current, documented)
- Stop matching methods and throw ArgumentException (breaking for anyone relying on it, though 8.3.3's method branch never worked)
- Add an opt-in overload / flag for methods and make the default properties-only in the next major version

Recommendation: Option 2 or 3. The method branch never produced a working expression in 8.3.3, so removing it breaks no working code. Properties-only is the safer default for a 'PropertyExpression'.

### API surface trimming / renaming for a major version

*Area:* Packaging / docs / tooling

643 public methods on the YAN* classes (plus 18 on IdGenerator), many singular/plural pairs (Abss/Sqrts/Titles...) and many object/unconstrained-T extensions. Package validation now guards against accidental breaks.

Options:

- Keep the surface; only add
- Mark redundant forms [Obsolete] in 8.x and remove them in 9.0
- Do a 9.0 redesign (fewer object/T extensions, consistent naming)

Recommendation: Option 2: deprecate first, then let package validation with a 9.0 baseline enforce the removal.

### N5: scalar WaitAny/WhenAnyWithCondition swallow predicate exceptions; streaming variants propagate them

*Area:* YANTask / YANProcess / YANText / Snowflake

Behaviour preserved and now documented in the XML docs and YANTask.md; tests pin both.

Options:

- Keep and document (current)
- Propagate in the scalar methods too (breaking: a faulted task instead of skip)
- Swallow in the streaming methods too

Recommendation: Propagate in both in the next major; swallowing hides predicate bugs.

### N6: WaitAny* and WhenAny* are identical although the docs described different semantics

*Area:* YANTask / YANProcess / YANText / Snowflake

The docs now say they currently behave identically.

Options:

- Keep both, documented as identical (current)
- Mark WhenAny* [Obsolete] in favour of WaitAny*
- Give WhenAny* distinct semantics (e.g. wait for all, return the first match in completion order)

Recommendation: Mark WhenAny* [Obsolete] in a minor release and remove it in the next major.

### Extract*Components keep an ignored 'sequence' parameter

*Area:* YANTask / YANProcess / YANText / Snowflake

The public signature must stay; the parameter is now ignored and documented as such on all 6 overloads.

Options:

- Keep it ignored (current)
- Add overloads without it and mark the old ones [Obsolete]
- Remove it in the next major

Recommendation: Add parameterless-sequence overloads plus [Obsolete] in a minor release (check CS0121 with a scratch consumer first), remove in the next major.

### LINQ shadowing by YANMath collection overloads

*Area:* YANMath / YANRandom

With 'using YANLib;', calls such as List<string>.Min() and List<DateTime>.Max() are ambiguous (CS0121) between Enumerable.Min<TSource> and YANMath.Min<T>(IEnumerable<T?>?). My probe hit it: new List<DateTime>{...}.Max<DateTime>() did not compile. int, long, double and decimal are fine because LINQ's non-generic overloads win. OverloadResolutionPriority cannot help across declaring types.

Options:

- Document only (status quo)
- Rename the collection overloads to MinOrDefault/MaxOrDefault/SumOrDefault/AverageOrDefault (major version)
- Move the IEnumerable<T?> Min/Max/Sum/Average overloads into an opt-in namespace, e.g. YANLib.Linq (major version)
- Keep only the static params/object forms and drop the extension form of the generic collection overloads (major version)

Recommendation: Document the CS0121 cases in YANMath.md now. In 9.0 move the generic collection overloads into an opt-in YANLib.Linq namespace, which keeps the names for users who want them and stops shadowing LINQ for everyone else.

### YANMath overflow semantics (Area A handed this over)

*Area:* YANMath / YANRandom

Kept and now documented: a result that does not fit T is default (0, or null for a nullable T), never an OverflowException. Examples: int.MinValue.Abs() == 0, 100000.Pow(2) == 0 for int, and the int sum of Enumerable.Range(0, 100_000) == 0, where LINQ throws. The new exact computation keeps this; only values that were wrongly out of range through double (long.MaxValue and similar) now come back.

Options:

- Keep default/null (current, documented in the XML remarks and YANMath.md)
- Throw OverflowException like LINQ and checked arithmetic (breaks the library's never-throw contract)
- Saturate to MinValue/MaxValue (CreateSaturating)
- Add opt-in variants (SumChecked/PowChecked, or an overflow-mode parameter), or a Sum<TSource, TResult> that widens, keeping today's default

Recommendation: Keep default/null in 8.x. Add opt-in checked and widening variants in a minor release, with a scratch consumer check for CS0121. Do not change the default before 9.0, and then only together with the decision on the never-throw contract.

### Public generic-math API

*Area:* YANMath / YANRandom

The precision and zero-boxing gains are internal: typeof dispatch over the 13 numeric types. Public 'where T : INumber<T>' overloads with the same names cause CS0111 in YANMath, CS0121 from any other class in namespace YANLib (16.0.Sqrt() breaks), and a constrained Round<T>(this T, int) would silently rebind existing calls.

Options:

- No new public API: the internal dispatcher is enough (current)
- New names with INumber<T> constraints (SumNumber, RoundNumber, ...)
- Constrained overloads in an opt-in namespace YANLib.Numerics
- A major version in which the constrained signatures replace the unconstrained T/object overloads

Recommendation: Keep it internal in 8.x. If users ask for compile-time numeric constraints, add YANLib.Numerics in a minor release, check overload resolution with a scratch consumer, and leave the YANLib namespace unchanged.

### Params overload design

*Area:* YANMath / YANRandom

The params overloads cannot take extra arguments: Rounds(params T?[]) always uses no digits and AwayFromZero; Logs(params) is always the natural log; there is no Pows(params). A single argument to GenerateRandom(params T[]) picks that argument. Two typed arguments now bind to the new GenerateRandom<T>(T, T) range overload, so picking one of two values needs an array.

Options:

- Keep and document (current; the params remark now says to pass two values as an array)
- Add leading-parameter overloads such as Rounds(int digits, params T[] values), checking CS0121 against the object?-digits overloads
- Remove the params overloads of the aggregates and GenerateRandom in a major version

Recommendation: Keep and document in 8.x. In 9.0, drop params on GenerateRandom (explicit arrays or collections only) and review whether the math params overloads are worth their ambiguity.

### Full-range random calls never return MaxValue

*Area:* YANMath / YANRandom

Every range is [min, max) and a null max means MaxValue, so NextUlong(), NextInt(), NextLong(), GenerateRandom<int>() and the others never return the type's MaxValue (NextUlong() could before, because of its old bug). float, double and decimal defaults are MinValue/100..MaxValue/100.

Options:

- Keep half-open everywhere (current, documented)
- Treat a null max as inclusive (the whole type range including MaxValue), e.g. through NextInt64() or NextBytes
- Add explicit inclusive overloads or a flag (NextIntInclusive or similar)

Recommendation: Keep half-open for explicit bounds. In 9.0 consider making the no-bounds calls cover the full range including MaxValue, since 'a random int' reads that way; it is a semantic change, so not in 8.x.

### Decision 2 with corrected scope: text-conversion cost of double/float elements with an integer or decimal result type

*Area:* YANMath / YANRandom

With an integer or decimal result type, Sum and Average convert each fractional double or float with more than 15 significant digits to decimal through its shortest round-trip text, which is slower than the 8.3.3 double sum. The earlier wording limited this to object collections. It also applies to typed double/float collections whose result type differs from the element type: doubles.Sum<decimal>(), doubles.Sum<long>() and doubles.Average<long>() bind to the non-generic Sum/Average<T>(IEnumerable?) overload, which boxes every element. Same-type typed calls such as YANMath.Sum<double>(doubles) or YANMath.Average<double>(doubles) are not affected. Int collections with another result type (ints.Sum<long>()) box but take the fast integer conversion. YANMath.md now documents this scope (ece8d88).

Options:

- Keep the exact conversion and document the scope (current state)
- Make the conversion allocation-free and faster without changing results: shortest digits written straight into a decimal, no string parse. Measure with BenchmarkDotNet
- Add a runtime fast path in the IEnumerable overloads for IEnumerable<double>/IEnumerable<float> that avoids boxing. This saves the box only; the text cost remains
- Sum double elements as double when the result type is an integer type, as in 8.3.3. Fast, but gives up exactness (behaviour change, major version only)

Recommendation: Option 1 for 8.x (done). Then option 2 as a separate perf change with benchmarks, because it keeps every result identical. Do not choose option 4 outside a major version.

### NextString character source (seeded reproducibility)

*Area:* YANMath / YANRandom

NextString(this Random random, object? size) draws its characters from Random.Shared (8.3.3: a new Random per character). The passed instance draws only the length when size is null. A seeded Random therefore never gave reproducible strings, so no existing seeded string output could break. This is now documented (12c194a). Taking the characters from the passed instance would make strings reproducible, but it has costs. (1) It changes how many draws NextString takes from the caller's instance, so every later value from that seeded instance shifts. (2) Sizes of 1000 or more go through GenerateRandomsImplement's AsParallel branch, and a non-thread-safe System.Random cannot be shared across PLINQ workers, so that branch would have to become sequential (or lock) for the passed instance. (3) It is a visible behaviour change of a public method.

Options:

- Keep the current behaviour (characters from Random.Shared, length from the passed instance), now documented in the XML remarks and YANRandom.md.
- Draw the characters sequentially from the passed instance (random.NextCharImplement() per character, no AsParallel): seeded strings become reproducible, but later draws from a seeded instance shift and large strings lose parallelism.
- Keep NextString as is and add a new opt-in member for seeded strings (for example a NextString overload or a separately named method that uses the passed instance), with no change to existing call sites.

Recommendation: Option 1 for this release, since it is documented and non-breaking. If seeded strings are wanted, do option 2 in the next major version (or option 3 if a minor-version addition is preferred), with a behaviour-change note.

## Other open decisions (non-breaking, not chosen yet)

Today's behaviour is documented in the wiki pages; these can be picked up in any minor release.

### Dictionary conversion when two keys parse to the same value (N8)

*Area:* Parse / collections

Parses<TKey,TValue>(IDictionary), ToDictionary and ToImmutable(Sorted)Dictionary use Add, so keys like "1" and 1, or "3.2" and "3.7" (both floor to 3), throw ArgumentException. This is unchanged.

Options:

- Keep throwing and document it on the correct method (the docs are currently swapped)
- Last value wins (indexer)
- First value wins (TryAdd)
- Add an overload with a conflict policy / merge delegate

Recommendation: Keep throwing in 8.x (silent data loss is worse) and fix the docs, then add an overload with a conflict policy.

### Overflow semantics for conversions (Parse, YANMath results)

*Area:* Parse / collections

Out-of-range conversions now return 0, null or defaultValue instead of crashing, which follows the existing never-throw contract. As a result int.MinValue.Abs() == 0 and int 100000.Pow(2) == 0, which is mathematically surprising.

Options:

- Keep default/0/null (current)
- Throw OverflowException (breaking for the never-throw contract)
- Saturate (CreateSaturating: int.MaxValue)
- Return null for nullable targets and default otherwise (current for Parse), but saturate or widen for YANMath

Recommendation: Keep default/null for Parse (never-throw contract). Let Area C decide YANMath separately, where saturation or an explicit checked variant is more useful than 0.

### Parallelism for CPU-heavy collection helpers after removing PLINQ

*Area:* Parse / collections

Measured on 4 CPUs, unordered PLINQ gave lower wall time for Titles and Serializes at 10k-100k items (13 ms vs 21-22 ms at 100k) at 2x the CPU, but returned a scrambled order. The decided fix (sequential, no AsOrdered) is implemented.

Options:

- Keep sequential and document the caller-side recipe `input.AsParallel().AsOrdered().Select(x => x.Title())`
- Add opt-in ordered parallel overloads (e.g. a ParallelOptions/degree parameter) using AsOrdered
- Re-introduce automatic AsOrdered PLINQ above a threshold

Recommendation: Keep sequential and document the recipe. Add opt-in overloads only if users ask; avoid automatic parallelism inside a library.

### A string defaultValue together with a format for Parse<DateTime>

*Area:* Parse / collections

Only a DateTime-typed defaultValue is used as is now. A string default is still parsed with the given format, so `"bad".Parse<DateTime>("2025-01-01", "dd/MM/yyyy")` still returns DateTime.MinValue (unchanged 8.3.3 behaviour).

Options:

- Keep (current)
- Parse the string default with the format, then fall back to a general DateTime.TryParse
- Parse the string default without the format

Recommendation: Option 2: format first, then general parse. It honours defaults written in either form and only changes results that are DateTime.MinValue today.

### Case-sensitivity and re-enumeration of the `names` overloads (A3, spec-listed)

*Area:* YANObject / YANExpression

AllPropertiesDefault(names) and the related overloads match names with names.Contains(prop.Name), which is case-sensitive, while IsValidField / PropertyExpression are case-insensitive with an exact match preferred. `names` is re-enumerated once per property and per element in the collection overloads.

Options:

- Keep case-sensitive and document it (done in YANObject.md)
- Use the IsValidField lookup (exact first, then case-insensitive) and materialise `names` once into a set
- Add an overload taking a StringComparer

Recommendation: Option 2 in the next minor release, listed as a behaviour change. It makes the names overloads agree with IsValidField, which callers typically use to validate the same names.

### Single vs collection `names` overloads validate differently (A4, spec-listed)

*Area:* YANObject / YANExpression

The single-object overloads reject `names` only when it is null, empty or all-whitespace (blank entries are ignored). The collection overloads require names.AllNotNullWhiteSpace, so any blank entry makes them return false. ["Name", null] therefore behaves differently in AllPropertiesDefault vs AllPropertiesDefaults.

Options:

- Keep as is (documented in XML only implicitly)
- Make the collection overloads ignore blank entries like the single ones
- Make the single overloads reject any blank entry like the collection ones

Recommendation: Option 2. Ignoring blank entries is the more forgiving rule and matches the single overloads used most often.

### Naming / visibility inconsistencies and static reflection caches (A5, A2, spec-listed)

*Area:* YANObject / YANExpression

The implementation's ValidField methods are `public static` in an internal class while the rest are internal. AnyNullDefault forwards to AnyNullEmptyImplement and similar. The static caches (PropertyCache, DefaultValueCache, CopyPropertyCache, the time-zone leaf, collection and dictionary caches, and the YANExpression cache keyed by user strings) hold strong Type references, which prevents collectible AssemblyLoadContexts from unloading; the expression cache is unbounded.

Options:

- Leave as is (documented that the expression cache is never trimmed)
- Rename/align visibility in the implementation only (no public impact) and switch the Type-keyed caches to ConditionalWeakTable<Type, ...>
- Additionally bound the expression cache (e.g. only cache names that resolved, or an LRU)

Recommendation: Option 2 plus caching only successful lookups. That needs no public API change. Implementation renames are safe because the facade is unchanged.

### Copy<T> for value types (implemented differently from the spec's literal wording)

*Area:* YANObject / YANExpression

The spec said 'Structs: copy into a boxed copy and unbox'. Copying settable properties into a boxed new T() still returns default values for structs without settable properties (5.Copy() == 0, DateTime.Copy() == MinValue, Guid.Copy() == Empty), which was the reported bug. Boxing the input and copying its properties into itself is a no-op. I implemented 'return the value itself' (and a new box for a boxed struct typed as object), which matches 'shallow copy' for value types.

Options:

- Keep: return the value (all fields copied)
- Literal spec: Activator.CreateInstance + settable properties into the box, then unbox (primitives and read-only structs become default)
- Throw NotSupportedException for value types

Recommendation: Option 1.

### IsNotValidField semantics for blank names

*Area:* YANObject / YANExpression

To make 'a blank name is never a valid field' hold in every method and keep the 8.3.3 All = !Any(opposite) centralisation sound, IsNotValidField is now exactly !IsValidField, so IsNotValidField(null) is true (8.3.3: false; the method did not exist in 8.3.2). The alternative three-valued reading (blank is neither valid nor not valid) would keep IsNotValidField(null) == false and use All(IsValid) / All(IsNotValid), making AnyNotValidField(["Name", null]) false, which is weaker as an input-validation guard.

Options:

- Keep two-valued (implemented; 3 tests corrected)
- Three-valued: blank is neither; AllNotValidFields(["Bogus", null]) and AnyNotValidField(["Name", null]) become false

Recommendation: Option 1. It matches the XML docs ('does not represent a valid field') and rejects blank sort fields.

### ChangeTimeZoneAllProperty coverage limits

*Area:* YANObject / YANExpression

Documented limitations: HashSet<DateTime>, Queue<T> and other non-list collections are not changed. Dictionary values that are not DateTime/DateTime? (e.g. Dictionary<string, Order>) are not walked. Multi-dimensional arrays are skipped. There is no depth guard against getters that create a new object on every call.

Options:

- Keep and document (current)
- Walk reference-typed elements of any ICollection<T> and dictionary values in place (no write-back), and add a depth limit that throws a clear exception
- Rebuild sets (HashSet<DateTime>) by clearing and re-adding converted values

Recommendation: Option 2 for dictionary values and ICollection<T> reference elements plus a depth guard. Avoid option 3 because it changes set identity and ordering semantics.

### Walking and copying both a base property and the `new` property of another type that hides it

*Area:* YANObject / YANExpression

To restore 8.3.3, Copy and ChangeTimeZoneAllProperty now handle both properties when a derived class hides a base property with `new` and a different type. This is right when the two have separate storage; that is the verifier's data-loss case. When the derived property forwards to the base one (`new DateTime? When { get => base.When; set => base.When = value ?? default; }`), the DateTime is converted twice, because value-type DateTimes are not in the visited set. Measured on the new tree: 10:00 -> next day 00:00. 8.3.3 does the same by code reading. The previous HEAD 45fad3a converted it once but lost independent base values.

Options:

- Keep both properties, as in 8.3.3 and as now implemented, and document that a forwarding `new` property of another type is converted twice
- Keep only the most-derived property for the walk but both for Copy (copying twice is harmless) and list 'independent hidden base DateTime no longer converted' as a behaviour change
- Keep only the most-derived property for both and document the loss for Copy and the walk

Recommendation: Option 1 (implemented). It matches 8.3.3 for a patch release. Forwarding `new` properties of a different DateTime type are rare, while silent data loss in Copy is worse. Option 2 is the alternative if the double shift turns up in practice.

### Guard against never-ending object graphs in ChangeTimeZoneAllProperty (updates the recorded 'no depth guard' decision)

*Area:* YANObject / YANExpression

The walk now uses a work list instead of recursion, so it has no depth limit. A getter that returns a new object on every call, of a type that leads back to itself, therefore runs until memory runs out. 8.3.3 and 20e2b7a crashed with a stack overflow instead. A getter-only list that builds new wrapper objects over a cyclic model (e.g. List<View> Neighbors => ...Select(n => new View(n))) also runs until memory runs out; 8.3.3 returned normally because it never walked getter-only properties, and 20e2b7a overflowed the stack. Each object is visited once and has finitely many properties, so a graph that never ends always means unbounded depth; a depth limit separates it from a wide finite graph, and an object count does not.

Options:

- Keep no guard. A never-ending graph ends in OutOfMemoryException; under a 512 MB heap limit that took about 4.2 s.
- Carry a depth with each work-list entry and throw InvalidOperationException once it passes a large documented limit (for example 1 000 000 levels, far above the 8.3.3 stack ceilings of about 3 000 on a 1 MB thread and 30 000 on the main thread).
- Cap the total number of objects visited per call. This is simpler, but it rejects wide finite graphs and does not target the real cause.
- Go back to recursion with RuntimeHelpers.EnsureSufficientExecutionStack. This gives a catchable InsufficientExecutionStackException, but the depth ceiling is lower than 8.3.3's.

Recommendation: Option 2 if the maintainers want a fail-fast guard: depth uniquely identifies endless generation and the limit can be far above anything 8.3.3 handled. Otherwise keep option 1, which is the current, documented behaviour.

### Scope of the getter-only collection rule in ChangeTimeZoneAllProperty

*Area:* YANObject / YANExpression

8.3.3 never walked getter-only properties. The walk now walks a getter-only property whose declared type is an array, a list or a dictionary class or interface. Two framework wrappers broke this rule and were fixed one by one: ArraySegment<T>.Array converted the whole array, and Lazy<T>.Value ran the factory. Other framework getter-only collections are still reached, such as Exception.Data and ThreadLocal<T>.Values, as is the getter-only 'view' case in the guard decision. The first recommendation was to walk getter-only collection properties only when the declaring type is not a framework type, which removes the whole class of wrapper and backing-store problems without losing the DTO use case that motivated the rule.

Later evidence (r4 probe goandcopy / copyandgo, 4 cultures): a field exposed both by a getter-only collection property and by a writable copy getter is now shifted twice, in either declaration order. Examples are `List<DateTime> View => _d;` with `List<DateTime> Copy { get => _d.ToList(); set => _d = value; }`, and `DateTime[] _d` behind `List<DateTime> Days { get => _d.ToList(); set => _d = value.ToArray(); }` plus `IList<DateTime> View => _d`. With (0, 7), 10:00 becomes 00:00 the next day (+14 h); 8.3.3 gave 17:00 (+7 h). This is now documented (md:153 no longer says 'as in 8.3.3' for it, plus a 'Changes since 8.3.3' entry) and pinned by ChangeTimeZoneAllProperty_GetterOnlyListAndCopyGetterOverOneField_ShiftsItTwice_Object. The DTO is a user type, so the earlier recommended option (skip framework-declared getter-only properties) does not remove this double shift. For dictionary and IList<DateTime?>-only types, the walk of their own properties (finding 1) already skips getter-only properties for the same reason.

Options:

- Keep the current rule with its exclusions; the double shift stays documented and pinned.
- Walk getter-only collection properties only when the declaring type is not a framework type (declaring assembly not System.Private.CoreLib / System.*). This fixes the framework wrapper and backing-store cases, but NOT this double shift.
- Heuristic: skip a getter-only collection property when the same type also has a writable property of a collection type (assume 'view plus serializer copy'). This removes this shape but stops converting getter-only DTO lists whenever the DTO has any other writable list, which makes it fragile.
- Revert to 8.3.3 and never walk getter-only properties. This removes this double shift and every wrapper problem, but loses in-place conversion of `List<T> Items { get; }` DTO lists (CA2227 style), the common case that motivated the rule.

Recommendation: Option 2, keeping the documented double shift for user DTOs. A field behind both a getter-only view and a writable copy getter is the same once-per-path class as two copy getters over one field, which also double-shifts in 8.3.3. Choose option 4 instead only if this patch release must match 8.3.3's final values on every shape.

### Items of custom IList<T>-only collection types in ChangeTimeZoneAllProperty

*Area:* YANObject / YANExpression

Types that implement IList<T> or IReadOnlyList<T> but not the non-generic IList (ArraySegment<T> is now special-cased) have their public properties walked, not their items. 8.3.3 threw TargetParameterCountException when their indexer had a setter.

Options:

- Keep the current behaviour (properties walked, items not).
- Walk their items through a cached generic IList<T> converter, as for ArraySegment<T>, writing back only when !IsReadOnly.
- Treat them as leaves.

Recommendation: Option 2, for consistency with IList and ArraySegment<T>; document it as a change from 8.3.3, which threw.

### Copy() on collection types

*Area:* YANObject / YANExpression

Copy copies only readable and writable properties, so new List<int>{1,2}.Copy() and a List-derived DTO lose their items without any warning (now documented). 8.3.3 threw TargetParameterCountException for every such type, because all of them have an indexer, so no 8.3.3 caller depends on the call succeeding.

Options:

- Keep the documented behaviour (settable properties only; items dropped).
- Throw NotSupportedException for IList, IDictionary and ICollection<T> types other than string.
- Copy the items shallowly (Add each item into the new instance) in addition to the properties.

Recommendation: Option 2: it turns silent data loss into a clear error and breaks no 8.3.3 caller. Option 3 is a feature that can be added later if wanted.

### ChangeTimeZoneAllProperty: which walked values are written back

*Area:* YANObject / YANExpression

The HIGH finding asked for 8.3.3's write-back of walked class values to be restored. It is implemented post-order and gated: a property or writable-list item is set only when a DateTime was converted in its value or below it. 8.3.3 set every writable property with a non-null value, strings and numbers included, and every list item. So a setter that rejects all writes (a read-only CultureInfo property, a frozen model) failed the walk, and ObservableCollection raised Replace for unchanged items. The gate also over-reports in one case: a struct item of a typed read-only list is converted in a discarded copy and still triggers the owning property's setter. That case is documented.

Options:

- (a) Keep the gate (current): set only values with a converted DateTime inside, post-order, and skip second references to already-walked objects.
- (b) Set every walked (non-leaf, first-visit) value post-order regardless of change, closer to 8.3.3 but re-introducing throws for read-only/frozen properties.
- (c) Full 8.3.3 parity: also set leaf values (strings, numbers) and second references (shared objects would still be converted once).

Recommendation: (a): it converts every copy-getter, computed and JSON-backed case 8.3.3 converted, without 8.3.3's spurious setter calls and throws. To flip to (b), drop the `if (!Changed) return;` gate in TimeZoneNode.Complete.

### State exposed through copy getters over the owner's own (or otherwise reachable) DateTime data is converted once per path

*Area:* YANObject / YANExpression

Restoring 8.3.3's interleaved order fixes the Appt/DTO case. It also brings back 8.3.3's double conversion for some shapes: a wrapper property over the owner's own Start/End (EvBefore, EvBetween, EvAfter, OrderVm), a copy getter next to a direct reference to the same object (SnapHolder), and two copy getters over one field (TwoCopies). These are now pinned by WrapperDeclaredBetweenItsDateTimes_ShiftsThemTogether and documented in YANObject.md and the XML remarks. The walk cannot tell that a copy aliases state it has already converted, or will convert, through another path.

Options:

- Keep 8.3.3's behaviour: convert once per path and document it (current state).
- Snapshot every DateTime before the walk and convert each distinct storage location once. This is not possible in general: reflection cannot see the field behind a computed getter.
- Add an opt-in overload or flag to skip computed or copy-returning writable properties (e.g. walk only auto-properties, or only properties whose getter returns the same reference twice). This is new API.
- Skip writable properties whose getter returns a new object on each read (two reads compared by reference). This changes behaviour for JSON-backed and defensive-copy properties that 8.3.3 handled.

Recommendation: Option 1: keep 8.3.3's behaviour and the documentation. It is what 8.3.3 users got, it is now deterministic and independent of declaration order, and the alternatives are either impossible in general or new API or behaviour that belongs in a minor release.

### ChangeTimeZoneAllProperty: user subclasses of non-data framework types (TextWriter/StringWriter, CancellationTokenSource, Task, Stream, ...) are leaves

*Area:* YANObject / YANExpression

IsTimeZoneLeaf treats every type assignable to TimeZoneLeafBaseTypes (MemberInfo, Assembly, Module, ParameterInfo, Delegate, Stream, TextReader, TextWriter, Task, WaitHandle, Thread, CancellationTokenSource, SafeHandle, Pointer) as a leaf. A user class deriving from one of them therefore keeps its own DateTime properties unconverted, whether it is the root, a property value or a list item. Measured with the probe (leafsub.prop, leafsub.root, tasksub): `class LogWriter : StringWriter { public DateTime Started { get; set; } }`, `class Job : CancellationTokenSource { DateTime Due }` and `class Work : Task { DateTime Due }` were converted by 8.3.3 (17:00) and are now left at 10:00. The leaf list exists because reading these types' inherited getters threw or did harm (MemoryStream.ReadTimeout threw in 8.3.3). This is now documented (md leaf rule, XML remarks, 'Changes since 8.3.3') and pinned by ChangeTimeZoneAllProperty_SubclassesOfNonDataFrameworkTypes_AreNotWalked_Object; the leaf logic is unchanged.

Options:

- Keep (current): every subclass of a leaf base type is a leaf; documented and pinned.
- Walk only the properties DECLARED by non-framework subclasses: for a type assignable to a leaf base whose own assembly is not a framework assembly, walk only the properties whose DeclaringType is not a framework type, never the inherited framework properties (Stream.ReadTimeout, TextWriter.Encoding / NewLine, Task.*, CancellationTokenSource.Token). This restores 8.3.3's results for the measured shapes without reading framework getters.
- Walk all properties of such subclasses, as 8.3.3 did: this reads and may write back inherited framework properties (Stream timeouts, which throw and would now be skipped; TextWriter.NewLine / FormatProvider; StreamWriter.AutoFlush) and walks into framework internals, which is the problem the leaf list fixed.

Recommendation: Option 2, in a later release, listed as a behaviour change from this release. It restores 8.3.3's conversion of user data on these classes and keeps framework getters unread. Keep option 1 for this patch, since it is documented and pinned.

### Dictionary / IList<DateTime?>-only types: own properties walked after their values (finding 1), and the wrapper whose writable property returns its backing collection

*Area:* YANObject / YANExpression

To restore 8.3.3's results, the walk now converts the values or items through the interface (as 1bb38c4 did) and then walks the type's own readable and writable properties (as 8.3.3 did). Getter-only properties are not walked, so a getter-only view of the backing store is not converted again (x.viewdict converts once). A type whose own WRITABLE property returns the collection behind its interface (`IList<DateTime?>` over `public List<DateTime?> Backing { get; set; }`, or an explicit IDictionary<string, DateTime> over `Dictionary<string, DateTime> Inner { get; set; }`) is converted through the interface and again through that property: 00:00 the next day (+14 h). Before, 1bb38c4 gave +7 h but lost the type's own DateTime properties; 8.3.3 left DateTime? items unchanged, or threw TargetParameterCountException for a Dictionary backing. This is documented (md once-per-path sentence, 'Changes since 8.3.3', XML remarks) and pinned by ChangeTimeZoneAllProperty_NullableDateListTypeExposingItsBackingList_ShiftsItTwice_Object.

Options:

- Keep (current): convert through the interface, then walk the own readable and writable properties; the wrapper alias is documented and pinned.
- For user (non-framework) types that implement these interfaces, walk only their properties and do not convert through the interface. This gives exactly 8.3.3's final values for these shapes, but explicitly implemented writable dictionaries and IList<DateTime?>-only types would no longer have their values converted (1bb38c4 converted them, and spec B5 asks for dictionary values to be converted).
- Walk all readable properties of these types, including the getter-only collection rule, for consistency with other objects. This adds double conversion through getter-only views (x.viewdict would go from 17:00 to 00:00 the next day).

Recommendation: Option 1. It matches 8.3.3 for the own properties and keeps the spec's value conversion. Aliasing through a public writable backing property belongs to the documented once-per-path class.

### Merge YANLib.Implementation into YANLib

*Area:* Packaging / docs / tooling

Two assemblies ship in one package. This needs InternalsVisibleTo and the custom IncludeImplementationAssembly pack target.

Options:

- Keep two assemblies (status quo; the pack target now works)
- Merge the implementation sources into YANLib as internal classes (one assembly, no consumer break, removes InternalsVisibleTo and the pack target)
- Keep the separate project but compile its sources into YANLib via <Compile Include> links

Recommendation: Option 2 in a future minor version, after areas C/D land, since it touches every file pair.

### Trimming/AOT annotations and multi-targeting

*Area:* Packaging / docs / tooling

net8.0 only; reflection-heavy areas (YANObject, YANExpression, YANUnmanaged) have no trimming annotations.

Options:

- Keep net8.0 only, no annotations
- Add IsTrimmable/IsAotCompatible plus annotations, fixing the warnings
- Also target net10.0

Recommendation: Option 1 for now. Revisit option 2 separately, since annotations on the reflection paths are design work.

### Test project references the Benchmarks exe (ConcurrentCollectionTests)

*Area:* Packaging / docs / tooling

test/YANLib.Tests references console/YANLib.Benchmarks only for ConcurrentCollectionTests.cs, which checks benchmark code rather than YANLib. This pulls BenchmarkDotNet into the test build.

Options:

- Keep as is
- Move ConcurrentCollectionTests and the Models it needs into the test project and drop the reference
- Delete the test (it does not test YANLib)

Recommendation: Option 2.

### WaitAnyWithConditions/WhenAnyWithConditions documented but internal

*Area:* Packaging / docs / tooling

**Resolved for 8.4.0: the methods are public and documented (see "Make WaitAnyWithConditions / WhenAnyWithConditions (and AsyncEnumerableEmpty) public").**

YANTask.md documents them as public (see deferred lines); they are internal in YANLib.Implementation and the facade exposes only the single-result variants.

Options:

- Expose public facade methods (additive, check CS0121 against the existing overloads)
- Remove them from YANTask.md
- Leave for area D

Recommendation: Area D decides. Option 2 is the safe default if no public API is wanted.

### Rename SnowflakelD.md (typo l for I)

*Area:* Packaging / docs / tooling

The wiki page name carries a typo; I linked it from the Sidebar under its current name.

Options:

- Keep the name
- Rename to SnowflakeId.md and update the Sidebar (breaks existing wiki links)
- Rename and leave a stub page linking to the new name

Recommendation: Option 3, done by the wiki owner.

### README 'Important Notes' block (ABP/EF text)

*Area:* Packaging / docs / tooling

README.md, at the end of Project Architecture, has notes about Elastic.Apm, DotNetCap.CAP, EF Core tools and 'Host'/'Domain.Shared' layers. None of these exist in this repo; they look like an ABP solution template. The README is also the NuGet readme. I left it in place.

Options:

- Keep
- Remove the block
- Move it to the wiki or a separate maintainer note

Recommendation: Option 2 if the owner confirms it is a leftover.

### PackageTags wording

*Area:* Packaging / docs / tooling

I converted the comma-separated tags 1:1 to 'C# .NET Library'.

Options:

- Keep 'C# .NET Library'
- Add descriptive tags (e.g. extensions utilities json text math random datetime snowflake)

Recommendation: Option 2 at the owner's discretion, for discoverability.

### Names that reduce to an empty file name now kill nothing

*Area:* YANTask / YANProcess / YANText / Snowflake

Before, 'dir/', '/', '.exe' or '.bashrc' reached Process.GetProcessesByName(""), which returns every process (105 of 105 here). As root that would have killed everything killable. Implemented as a no-op.

Options:

- No-op (current)
- Throw ArgumentException for such names
- Restore the old behaviour

Recommendation: Keep the no-op (consistent with null/blank names); an ArgumentException is acceptable if callers should learn about bad input.

### FormatName uses a [ThreadStatic] cached StringBuilder

*Area:* YANTask / YANProcess / YANText / Snowflake

stackalloc (no dynamic PGO) and ArrayPool versions measured 5-40% slower than the old code; the per-thread builder (cleared, capped at 1024 chars) measured 175-186 vs 197-201 ns with 58 vs 222 B.

Options:

- Keep the per-thread builder (current)
- ArrayPool buffer (no thread-static state, ~10% slower than old in the library measurement)
- Plain new StringBuilder (old speed, more allocation)

Recommendation: Keep the per-thread builder.

### Negative Snowflake IDs in NextIdAlphabetic/NextIdAlphanumeric

*Area:* YANTask / YANProcess / YANText / Snowflake

**Status in 8.4.0: unsigned encoding kept, and the recommended S8 validation is done. NextId* now throws ArgumentOutOfRangeException for an epoch later than now (65b0748), so a future epoch no longer produces a negative ID. The only negative IDs left are those made 2^40 ms (about 34.8 years) or more after their epoch, which set the sign bit (NextId(0L), the Unix epoch, does today). NextIdAlphabetic/NextIdAlphanumeric encode them as unsigned 64-bit values, and Extract* reads the timestamp field unsigned (1f32140), so they decode to the right date (8.3.3: 1957 for NextId(0L)).**

In 8.3.3 they threw IndexOutOfRangeException. The review implemented an unsigned 64-bit encoding, which keeps the documented A-Z / 0-9A-Z alphabet and round-trips through Extract* (long.MinValue, -1, 0, long.MaxValue checked).

Options:

- Unsigned encoding (current)
- Throw ArgumentOutOfRangeException for a negative ID
- Prefix a '-' sign (breaks the alphabet contract)

Recommendation: Keep unsigned, and prevent negative IDs at the source by validating timestampEpoch (S8). Both are in 8.4.0.

### Lower-case input to ExtractIdAlphabetic/AlphanumericComponents

*Area:* YANTask / YANProcess / YANText / Snowflake

Implemented strict rejection (ArgumentException), as the spec lists lowercase among the invalid inputs.

Options:

- Reject (current)
- Accept case-insensitively (upper-case before decoding)

Recommendation: Keep rejecting; base-36 IDs copied through case-folding systems could be accepted later as a non-breaking relaxation.

### Scale of decimal results

*Area:* YANMath / YANRandom

Native decimal arithmetic keeps scale (1.10m + 2.20m = 3.30m, 1.10m.Pow(2) = 1.2100m). 8.3.3 went through double and so always returned values without trailing zeros (3.3m). I chose the status quo: results are normalised by dividing by 1.0000000000000000000000000000m, verified on 200,000 random decimals.

Options:

- Normalise, as 8.3.3 output did (current)
- Return native decimal scale, as C# arithmetic does
- Make it configurable

Recommendation: Keep normalised in 8.x, so ToString output does not change for existing users. Revisit only together with a public decimal-specific API.

### Decimal aggregates whose intermediate sum overflows

*Area:* YANMath / YANRandom

Typed and object decimal Sum/Average fall back to the 8.3.3 double result when an intermediate sum overflows decimal. Sum then keeps its old answer (usually 0). Average(decimal.MaxValue, decimal.MaxValue) is still 0 although the exact average decimal.MaxValue fits.

Options:

- Keep the double fallback (current; never worse than 8.3.3)
- Compute Average without overflow, e.g. as a running mean or the sum of x/n with a correction term
- Accumulate in a wider exact type (BigInteger mantissa plus a common scale) and narrow at the end

Recommendation: Use the wider exact accumulation for Average in a minor release. Sum's out-of-range result stays default, per the overflow decision.

### Decimal result for whole doubles of 2^53 or more on the object path

*Area:* YANMath / YANRandom

Integer targets must use the exact value; that matches (long)x, Convert.ToInt64 and 8.3.3. Decimal targets now also get the exact value of the double, as the verifier recommended: ((object)7.9e28).Truncate<decimal>() = 78999999999999996926548246528 and ((object)1e23).Truncate<decimal>() = 99999999999999991611392. 8.3.3 used the 15-digit Convert.ToDecimal (79000000000000000000000000000; 1152921504606850000 for 2^60). HEAD used the shortest text (79000000000000000000000000000; 1152921504606847000). So gate rows v4, v27 and v28 differ from both 8.3.3 and HEAD.

Options:

- (a) Exact binary value for every whole double or float (current). It is consistent with integer targets, so Truncate<decimal> and Truncate<long> agree, and no information is lost.
- (b) Exact only below 2^64 (the integer-target range), and shortest text above. 7.9e28 then gives 79000000000000000000000000000, but there is a discontinuity at 2^64.
- (c) Shortest text for decimal targets (the HEAD behaviour) and exact only for integer targets. TryToDecimal would need the target type, and the decimal and long results would disagree for 2^60.
- (d) 15-digit Convert.ToDecimal, as 8.3.3 did. This loses digits, for example for 2^60.

Recommendation: (a), already implemented and documented in YANMath.md with the 1e23 example.

## Decisions recorded while building 8.4.0

These are follow-up choices found while the 8.4.0 additions were built. Most entries kept the behaviour they describe; the two marked *Done in 8.4.0* (the Snowflake sign bit and the YANTask null predicate) were implemented before the release.

### NextChar(char, char) removes the natural delegate type of the NextChar method group (CS8917)

*Area:* Random / YANMath / Snowflake (8.4.0)

The owner-chosen typed overload makes `var h = random.NextChar;` and `Delegate d = random.NextChar;` fail with CS8917 'The delegate type could not be inferred'. Both compiled against 2f3a038 (scratchpad/g1-consumer). Typed method groups (Func<char>, Func<Random,char>, Select(YANRandom.NextChar)), random.NextChar() and GenerateRandom<char> are unaffected. Binary compatibility is preserved, and package validation passes. Any second overload named NextChar would cause the same error.

Options:

- Keep NextChar(char, char) as chosen and note the CS8917 source impact in the 8.4.0 release notes
- Rename the ranged method (for example NextCharInRange) so NextChar keeps a single overload
- Revert the overload and keep GenerateRandom<char>(min, max) as the only ranged char API

Recommendation: Keep it (option 1). .NET's own compatibility rules treat a new overload as acceptable, the untyped method-group shape is rare, and the owner chose this exact signature. Mention it in the release notes.

### Strings with more than 28 decimal places and a decimal/integer result are still rounded to 28 places first

*Area:* Random / YANMath / Snowflake (8.4.0)

decimal.TryParse rounds such a string to 28 places, so ((object)"1.9999999999999998e-13").Round<decimal>(20, ToZero) is 0.0000000000002 (exact: 0.00000000000019999999). The same string with Round<double> now goes through its parsed double and is exact (1.9999999E-13). This is pinned by Round_StringMoreThan28DecimalPlaces_RoundsAt28PlacesFirst_MathGeneric and documented in YANMath.md. A string can carry more than 29 significant digits, which a decimal digit shift cannot hold exactly.

Options:

- Keep it (decimal-parse semantics for strings, documented and pinned)
- Digit-shift the string's own digits when they fit in 28-29 significant digits, otherwise keep the 28-place parse
- Route such strings through double.Parse and the double digit shift (loses digits beyond 17)

Recommendation: Keep it for 8.4.0 (option 1). Option 2 is the only exact one and could follow later if string inputs with that many places matter.

### Boxed decimal inputs with a double/float result keep the 28-places-first path

*Area:* Random / YANMath / Snowflake (8.4.0)

The object Round with a double/float result converts a decimal with the 8.3.3 cast, which is not correctly rounded: (double)1e-28m = 1.0000000000000001E-28. Digit shifting that double turned ((object)1e-28m).Round<double>(28, ToPositiveInfinity) from 1E-28 into 2E-28. A decimal input never needs more than 28 places, so 930c0ed keeps the old path for it (byte-identical to 2f3a038, pinned by Round_TinyDecimalToDouble_RoundsAt28PlacesFirst_MathGeneric). The cast error still leaks for larger decimals, as it did before.

Options:

- Keep the 2f3a038 path for decimal inputs (implemented)
- Round the decimal itself with decimal.Round(min(digits, 28)) and convert the result to double correctly rounded through text (exact for the decimal; changes the <=28-place class as well)
- Round the cast double exactly (digit shift), exposing the cast error in directed modes

Recommendation: Option 1 for 8.4.0. Consider option 2 for 9.0 together with the planned conversion changes.

### SpinWait.SpinOnce() vs SpinOnce(-1) in WaitForNextMillisecond

*Area:* Random / YANMath / Snowflake (8.4.0)

The spec's SpinOnce() cuts CPU while waiting from about 2000 ms to about 100 ms per 2000 waits. It occasionally calls Sleep(1), which overshoots the millisecond: 870-880 waits/s instead of about 1000. In the library with MoreDistributed (8 IDs/ms, 16,000 IDs), wall time went from about 2.0 s to about 2.3 s. SpinOnce(-1) (no Sleep(1)) kept the throughput (987-999 waits/s) but saved no CPU on an idle machine (1980 ms per 2000 waits), because Yield and Sleep(0) return at once. The ROADMAP's 'same latency, less CPU burn' cannot both hold.

Options:

- Keep SpinOnce() (implemented): about 95% less CPU, about 13% lower peak throughput when every millisecond's sequence is used up
- SpinOnce(-1): same throughput as 8.3.3, lets other ready threads run, but still burns a core when idle
- A hybrid: spin with SpinOnce(-1) until the next millisecond is near, then SpinOnce(); more code, needs measurement

Recommendation: Keep SpinOnce() (option 1), the owner's choice and the stated goal. Only strategies that use up their sequence every millisecond (MoreDistributed, 8 IDs/ms) feel the throughput cost. Document it, which SnowflakelD.md now does.

### Timestamps in [2^40, 2^41) set the sign bit and ExtractIdComponents misread them

*Area:* Random / YANMath / Snowflake (8.4.0)

**Done in 8.4.0 (1f32140): option 3. ExtractIdComponents, and through it the alphabetic and alphanumeric variants, read the timestamp field unsigned ((long)((ulong)id >> shift)), so every ID that 8.4.0 can generate decodes to its real date. Documented in the NextId remarks and SnowflakelD.md, and pinned by ExtractIdComponents_IdWithTheSignBitSet_ReadsTheTimestampUnsigned.**

The timestamp shift is 23, so the 41-bit field includes bit 63. The owner's bound (2^41 or more throws) accepts elapsed times of 2^40 to 2^41 - 1 ms, which give negative IDs. Before 1f32140, ExtractIdComponents used an arithmetic shift (id >> 23) and read their timestamp 2^41 ms (about 69.7 years) too early. This is current, not a 2057 problem: NextId(0L) (the Unix epoch) passes validation and returns a negative ID, which 8.3.3 and the arithmetic shift decoded to a date in 1957. Any epoch older than about 34.8 years behaves the same; with the default 2023 epoch, it starts in November 2057.

Options:

- Keep the 2^41 bound and the arithmetic shift (documented misread)
- Bound at 2^40 so IDs are never negative (a stricter behaviour change than the owner chose; epochs older than about 34.8 years would throw)
- Keep 2^41 and make ExtractIdComponents read the timestamp unsigned: correct for every ID 8.4.0 can generate, but it changes Extract for negative IDs that 8.3.3 generated with a future epoch
- Keep 2^41 and add an opt-in unsigned extraction overload

Recommendation: Option 3 in 8.4.0. With future epochs now rejected, the only negative IDs NextId can make are sign-bit ones, which the unsigned read decodes correctly. Note it in the release notes next to the epoch validation (done in CHANGELOG.md). If changing Extract had been too much for 8.x, option 2 was the safe alternative.

### Shape of the collection overloads for entireProcessTree/cancellation (deviation from the spec's example signature)

*Area:* YANTask / YANProcess (8.4.0)

The spec suggested KillAllProcessesByNames(this IEnumerable<string?>? names, bool entireProcessTree, CancellationToken cancellationToken = default). A compiled stub matrix showed that any non-generic (IEnumerable<string?>?, ...) overload with 2-3 parameters competes with the expanded params string?[] overload for literal-only calls. The C# normal-vs-expanded tie-breaker applies only to identical parameter types. With the spec shape, KillAllProcessesByNames(null, default) and (default, default) silently rebind (a no-op either way), and (null, default, default) and (default, default, default) become CS0121. Adding the token-only non-generic overload makes all four CS0121. This breaks the common rule (no CS0121, no silent rebinding). A generic form, KillAllProcessesByNames<TNames>(this TNames? names, ...) where TNames : IEnumerable<string?>, drops out of overload resolution for null/default literals because type inference fails. All 25 existing call sites bind to the same IL target on 07a75db and on the new tree, and list/array/ImmutableArray/IEnumerable receivers work. Cost: an unusual generic signature, and a null literal needs a typed variable or a cast (documented). I implemented the generic form.

Options:

- Generic collection overloads (implemented): zero rebinding or ambiguity on the measured matrix; the TNames type parameter shows in IntelliSense
- Spec's non-generic shape: simpler signature, but literal-only params calls rebind ((null, default)) or fail with CS0121 ((null, default, default))
- Single-name overloads only: fully safe; multi-name callers use Task.WhenAll(names.Select(n => n.KillAllProcessesByName(false, token)))
- Options type with a different method name (e.g. KillAllProcessesByNamesWith(names, options)): no overload interaction, but a new name that is inconsistent with the rest of the API

Recommendation: Keep the generic form for 8.4.0: it is the only same-name shape that meets the non-breaking rule. For 9.0, consider dropping the params overload or moving the options into a ProcessKillOptions parameter, so a plain IEnumerable<string?> overload becomes possible.

### Kill order for the existing and new methods: signal all first, then wait (two-phase)

*Area:* YANTask / YANProcess (8.4.0)

To give cancellation and timeouts a useful meaning, KillAndDispose now signals every matching process before waiting for any. Before, each process was killed and awaited in turn. For the existing methods the final result is the same; only the order and timing differ (processes die in parallel; a process that never exits no longer blocks the others from being signalled). The alternative, sequential kill-and-wait with the token, would leave the remaining processes unsignalled when a timeout hits on a stuck first process. That makes the timeout recipe much weaker. A test pins the two-phase behaviour.

Options:

- Two-phase signal-then-wait for all overloads (implemented)
- Sequential kill-then-wait, with cancellation stopping the loop (unsignalled processes remain on timeout)
- Two-phase only for the new overloads; keep sequential for the old ones (two code paths)

Recommendation: Keep two-phase everywhere. It is listed as a behaviour change and documented in YANProcess.md and the XML remarks.

### Precedence when a kill fails and the wait is also canceled

*Area:* YANTask / YANProcess (8.4.0)

The new overloads follow the existing 'first failure is rethrown' rule, and a canceled wait counts as a failure after every kill. So if a process could not be killed (e.g. Win32Exception access denied) and the token is then canceled, the caller gets the kill failure, not OperationCanceledException. Across names, Task.WhenAll likewise reports a faulted name before a canceled one. A caller that catches only OperationCanceledException for a timeout therefore sees the Win32Exception in that case. This is documented in the XML exception docs and YANProcess.md, and tested (KillAndDispose_FailureAndCanceledWait_RethrowsTheFailure_Process).

Options:

- Kill failure wins (implemented; consistent with first-failure and with Task.WhenAll)
- Cancellation wins: always throw OperationCanceledException when the token was canceled, losing the kill failure
- Throw an AggregateException with both

Recommendation: Keep 'kill failure wins'. It preserves the existing first-failure contract and surfaces the more serious error; the docs warn about it.

### KillAllProcessesByName method group loses its natural type (CS8917 source break) because of the 8.4.0 same-name overloads

*Area:* YANTask / YANProcess (8.4.0)

KillAllProcessesByName had one overload in 8.3.3. With the owner-chosen (string?, CancellationToken) and (string?, bool, CancellationToken) overloads, its method group has no natural type. Consumer code such as `var f = YANProcess.KillAllProcessesByName;` or `Delegate d = YANProcess.KillAllProcessesByName;`, which compiled against 8.3.3, now fails with CS8917. Explicitly typed delegates and Select method groups still bind to the old overload, and package validation (binary API) is unaffected. KillAllProcessesByNames already had two overloads. This is now documented in YANProcess.md and the ROADMAP, but it is a source break the owner has not explicitly accepted.

Options:

- Keep the same-name overloads as chosen and document the break (done in 17fb1e6; add it to PackageReleaseNotes at the bump)
- Rename the new single-name overloads (for example KillAllProcessesByNameWithOptions / KillAllProcessesByName with a different name for the token variants) so the original method group keeps its natural type, at the cost of the consistent naming the owner chose and of updating the docs and tests added in G2b

Recommendation: Option 1: keep and document. Assigning the method group to `var` or `Delegate` is rare, the fix at the call site is a one-word delegate type, the binary API is unchanged, and the same-name overloads match the owner's 8.4.0 choice and the .NET convention.

### YANTask streaming methods: the yield-order contract

*Area:* YANTask / YANProcess (8.4.0)

WaitAnyWithConditions and WhenAnyWithConditions check the tasks lazily in collection order and yield each one that is complete when it is reached. That includes a task that completed while the consumer handled an earlier result, so it comes before a later task that was already complete at the start ([1,tcs,3] gives [1,2,3]; taken 2 gives [1,2]). Running tasks are registered after that pass, in collection order, so those that have completed by then come in collection order ([a,b,3] with b completing before a gives [3,1,2]). This round documents that order exactly and changes no code. The verifier's alternative, snapshotting IsCompleted before the first yield, would change which results `taken` returns. On its own it would not make the rest strictly completion-ordered either: the [3,1,2] case would still come out in collection order.

Options:

- A: keep the current order, now documented exactly in the XML remarks and YANTask.md. No continuations or allocations when the already-complete tasks satisfy `taken`, and the check order matches the scalar WaitAny/WhenAnyWithCondition.
- B: snapshot IsCompleted for every task before the first yield, so tasks complete at the start come first in collection order and the others follow. This changes the `taken` results, and the rest is still not strictly completion-ordered (tasks that complete before registration still come in collection order).
- C: snapshot and register the InCompletionOrder continuations for every running task before the first yield, so the rest is in true completion order. This changes the `taken` results and registers continuations even when the already-complete tasks satisfy `taken` (the Leak tests would need rechecking).

Recommendation: A. The order is now documented precisely and pinned by tests. B gives only part of the guarantee and still changes results, and C adds cost for a guarantee nobody has asked for. Revisit only if the owner wants a strict completion-order contract before 8.4.0 ships.

### Null predicate in the YANTask methods (WaitAnyWithConditions / WhenAnyWithConditions and WaitAnyWithCondition / WhenAnyWithCondition)

*Area:* YANTask / YANProcess (8.4.0)

**Done in 8.4.0 (3c2ab80): option 3. The streaming methods throw ArgumentNullException (ParamName "predicate") from the first MoveNextAsync, next to the existing ArgumentException for a null task, whatever the tasks are. The released single-result methods still count a null predicate as no match. The XML docs, YANTask.md and the pinning tests were updated.**

Behaviour before 3c2ab80 (documented in 1d3f272 and pinned by tests):
- The streaming methods called the predicate without a null check. A null predicate threw NullReferenceException from MoveNextAsync at the first task that completed successfully, and gave an empty enumeration when no task succeeded or the collection was null or empty.
- The scalar methods catch every predicate exception. A null predicate counts as no match, and they return default(T) after waiting for all tasks.

Timing decided the options. The streaming methods became public for the first time in 8.4.0 (they were internal in 8.3.3), so validating them before the release breaks no released consumer. The scalar methods are already released, so changing them is a behaviour change for existing callers.

Options:

- Keep the behaviour as documented: streaming throws NullReferenceException lazily, scalar returns default(T).
- Throw ArgumentNullException eagerly in the facade of the streaming methods (when WaitAnyWithConditions is called, before enumeration), the BCL convention for iterator-returning methods. Leave the scalar methods as they are.
- Throw ArgumentNullException at the first MoveNextAsync in the streaming methods, so it fits the existing lazy-throw model of ArgumentException and OperationCanceledException.
- Validate in both families: ArgumentNullException in the streaming methods (eager or first MoveNextAsync) and also in the scalar methods, listed as a behaviour change for the scalar methods.

Recommendation: Option 3 before 8.4.0 shipped. It costs nothing for released consumers and turns a NullReferenceException that depended on the data (sometimes thrown, sometimes an empty result) into a consistent ArgumentNullException. Leave the scalar methods unchanged (their no-match handling is documented) unless the owner wants symmetry; then take option 4 in a later release and list it as a behaviour change.

### Should the IFormatProvider of ParseWith/ParsesWith also govern exact DateTime format strings?

*Area:* Parse with IFormatProvider (8.4.0)

The spec says to thread the provider through DateTime parsing "with and without formats". Today Parse matches exact formats with InvariantCulture ('/' and ':' are literal, invariant month names), and equivalence gate (1) requires ParseWith(CultureInfo.CurrentCulture) == Parse. If formats used the provider, gate (1) would fail for formats: under de-DE, "13/12/2025" with "dd/MM/yyyy" matches with invariant, and with the de-DE provider '/' means '.'. Implemented: formats stay invariant with any provider, documented in the XML docs and in YANUnmanaged.md, and pinned by ParseWith_ExactFormat_IsMatchedWithInvariantCulture and ParsesWith_DateTimeFormats_AreMatchedWithInvariantCulture_Collection. Evidence: $SP/equiv-G3/fmt-decision-probe.txt (25 input x format x culture cases). With the provider, de-DE would accept "13.12.2025" for dd/MM/yyyy and reject "13 December 2025" for "dd MMMM yyyy"; fr-FR would accept "13 décembre 2025".

Options:

- Keep exact formats invariant for every provider (implemented). Consistent with Parse, keeps gate (1) exact, and documented.
- Use the provider for exact formats in ParseWith only. Allows localized month names and separators, but ParseWith(CultureInfo.CurrentCulture, ..., format) then differs from Parse(..., format), and '/' or ':' in existing format strings changes meaning.
- Use the provider for exact formats only when it is non-null (null = invariant formats as today). Same consequence as option 2 for an explicit CurrentCulture, and the rule is harder to explain.
- Add a separate format-culture parameter or options type later (9.0, with the invariant-default change).

Recommendation: Option 1 for 8.4.0, as implemented. Revisit in 9.0 together with the planned invariant default (option 4), so that a format culture is chosen explicitly rather than inferred.

### When the compiled accessors are built (compile on second call vs eager)

*Area:* YANObject compiled accessors (8.4.0)

The spec asks for compiled getters/setters cached per type with an unchanged observable contract. Compiling eagerly at first use (the partial work) made the equivalence probe differ: .NET 8 reflection's interpreted first call runs a struct property type's precise static constructor before the getter, and a throwing one surfaces as TIE(TypeInitializationException). Implemented: each accessor's first call goes through reflection and its second call compiles. This mirrors .NET reflection's own tiering, makes the probe byte-identical (mixed sequences with ChangeTimeZoneAllProperty included), and means a type used once compiles nothing. Trade-off: the second call on a new type costs about 2x reflection's second call (IsNullDefault 6 props: 641 vs 298 µs; Copy 10 props: 1346 vs 512 µs). Steady state is 2-6x faster.

Options:

- Keep compile-on-second-call (as committed)
- Eager compile on first use, emulating the static-constructor trigger with RuntimeHelpers.RunClassConstructor on the first call (cheaper to explain; diverges after a failed static constructor or when another method made the first reflection call)
- Compile after N calls (for example 8 or 16), so rarely used types never compile; calls 2..N then pay reflection's own emitted-stub cost as well as the later compile
- Eager compile with no emulation, documenting the static-constructor timing difference as a behaviour change

Recommendation: Keep compile-on-second-call. It is the only option that keeps reflection's first-call semantics exactly, and its one-time cost (about 0.3-0.8 ms more per type) is paid back after a few thousand calls. Revisit with a higher threshold only if real workloads check many types just two or three times.

## CI and tooling

Decisions recorded when the CI workflow and `global.json` were added (Area F). Neither affects package consumers.

### Contributor impact of the committed global.json (8.0.100, rollForward latestFeature)

*Area:* CI and tooling

**Chosen by the owner (November 2026): option 2. Done in 8.4.0: the committed global.json is removed and the CI workflow writes it before setting up .NET, so contributors can use any SDK; the .editorconfig header says CI decides the format gate.**

latestFeature never crosses majors: a 9.0.100 + latestFeature global.json with only SDK 8 installed fails with 'A compatible .NET SDK was not found' (exit 145). So a developer who has only a .NET 9/10/11 SDK can no longer run dotnet build/test/format at the repository root, and Visual Studio honours global.json too. YANLib.sln says 'Visual Studio Version 18' (VS 2026, which ships the .NET 10 SDK), so the maintainer may not have an 8.0 SDK. .NET 8 support ended on 2026-11-10, so the file asks contributors to install an out-of-support SDK. The pin exists because the formatter output depends on the SDK version, and it gives a local `dotnet format` the same result as CI. Unverified risk: an unpinned newer SDK may report net8.0 as out of support, which TreatWarningsAsErrors could turn into a build break; that is a reason to keep a pin in CI either way.

Options:

- Keep global.json committed with latestFeature (current): local and CI use the same .NET 8 SDK and formatter, but contributors must install an 8.0 SDK, and VS 2026 users without one cannot load or build the solution.
- Generate global.json only inside the CI job (for example `dotnet new globaljson --sdk-version 8.0.100 --roll-forward latestFeature` before setup-dotnet) and drop the committed file: CI stays pinned and contributors use any SDK, but a local `dotnet format` on SDK 10/11 may disagree with CI.
- Commit global.json with rollForward latestMajor: contributors are never blocked, but the pin is gone. setup-dotnet maps latestMajor to no version, and the SDK resolver then picks the newest installed SDK (11.0.100 on the runner), so the formatter drifts with each runner image.

Recommendation: It depends on whether the maintainer has (or will install) an 8.0 SDK and wants the same formatter locally and in CI. If yes, keep option 1. If the maintainer works only with VS 2026 / SDK 10+, switch to option 2: CI keeps its pin and nobody is blocked locally; then add a line to the .editorconfig header saying that the format gate is defined by the .NET 8 SDK used in CI. Do not use option 3, since it gives up the pin that was the reason for global.json.

### SDK band in CI: latestFeature (8.0.4xx on the runner) vs latestPatch (8.0.1xx, what was measured locally)

*Area:* CI and tooling

**Settled: option 1 (keep latestFeature). The real GitHub runs on SDK 8.0.428 passed the build and the format gate, so no switch to latestPatch is needed.**

The ubuntu-24.04 image has 8.0.134, 8.0.206, 8.0.319 and 8.0.428 preinstalled. With latestFeature, setup-dotnet installs channel 8.0 and the resolver picks 8.0.428 or newer (Roslyn 4.11). Every local measurement, including the format gate, was made on 8.0.134 (Roslyn 4.8). Proxies for Roslyn 4.11 were clean (compiler toolset 4.11: 0 warnings and all tests passed; Formatter 4.11 changed 0 of 149 files), but the 8.0.4xx SDK's own `dotnet format` and its bundled analyzers had not been run before the first real CI run. With latestPatch, setup-dotnet would install the newest 8.0.1xx and the resolver would stay in the 1xx band, the band rehearsed locally.

Options:

- Keep latestFeature (current, the spec's choice): newest .NET 8 tooling.
- Switch global.json to rollForward latestPatch: CI uses the same 8.0.1xx band (Roslyn 4.8) as every local measurement, but contributors then need an 8.0.1xx SDK specifically (VS 2022 17.9+ ships 8.0.2xx-4xx), which is stricter locally.
- Keep latestFeature in the committed file and pin CI more tightly (for example a CI-generated global.json with 8.0.134 + latestPatch, combined with option 2 of the previous decision).

Recommendation: Option 1. The plan was to watch the first real run and apply option 2 (a one-line change to global.json) only if 'Check formatting' or 'Build' failed on 8.0.4xx alone; the runs on 8.0.428 passed both, so option 1 stays.
