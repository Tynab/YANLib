# Changelog

## 8.4.0

A large maintenance release. Every change was made against the 8.3.3 sources, checked by independent reviews, and is covered by tests (2186 tests, 0 failures) and by CI (build with warnings as errors, format check, the whole test suite and package validation against 8.3.3 on every push and pull request to `develop` and `main`). The wiki pages YANUnmanaged, YANObject, YANExpression and SnowflakelD have a *Changes since 8.3.3* section with more detail; for the other classes, this file is the full list. Design questions that were not changed in 8.x are listed in [ROADMAP.md](ROADMAP.md).

### New API

- **Parse with a culture**: `ParseWith<T>(IFormatProvider?)` and `ParsesWith<T>(...)` (9 overloads) parse with the given provider; `Parse` / `Parses` keep using the current culture. Under `vi-VN`, `"1.5".ParseWith<double>(CultureInfo.InvariantCulture)` is `1.5`.
- **Random**: `GenerateRandom<T>(T min, T max)` returns a value in `[min, max)` for the numeric types, `DateTime` and `char` (calls such as `GenerateRandom<int>(18, 80)` used to bind to `params T[]` and return one of the two arguments), and `Random.NextChar(char min, char max)`.
- **YANTask**: `WaitAnyWithConditions` / `WhenAnyWithConditions` are public. They stream every matching result as its task completes (the exact order is described on the YANTask wiki page), every cancellation throws `OperationCanceledException`, and a `null` predicate throws `ArgumentNullException`.
- **YANProcess**: overloads of `KillAllProcessesByName` / `KillAllProcessesByNames` take `bool entireProcessTree` (the existing methods keep killing the whole tree) and a `CancellationToken`; use `new CancellationTokenSource(TimeSpan)` for a timeout.
- **YANObject**: `IsNull()` / `IsNotNull()`, removed in 8.3.3 by mistake, are back as `[Obsolete]` shims with their 8.3.2 signatures. Use `is null` / `is not null`.
- **Snowflake**: `ExtractIdComponents(id, strategy, timestampEpoch)` and the alphabetic/alphanumeric forms without the ignored `sequence` parameter. The `BitAllocationStrategy` overloads that take `sequence` are `[Obsolete]` (warning) and bind only when `sequence` is passed; the overloads with custom bit counts keep their ignored `sequence` (see ROADMAP.md).
- **Duplicate dictionary keys**: `Parses<TKey, TValue>(IDictionary<object, object?>)`, `ToDictionary`, `ToImmutableDictionary` and `ToImmutableSortedDictionary` have an overload with a `Func<TValue?, TValue?, TValue?> onDuplicate` that receives the stored and the incoming value of a key that parses to an existing key (for `Parses`, `"1"` and `1`, or `"3.2"` and `"3.7"`, both floored to 3 where `.` is the decimal separator; for the conversions, for example the `double` keys 1.2 and 0.8, both rounded to the `int` 1) and returns the value to keep: `(stored, incoming) => stored` keeps the first. `Parses` reads the entries in the input's enumeration order without re-keying them, so two keys that the input's own comparer keeps apart (two distinct `"1"` strings under `ReferenceEqualityComparer`) reach it too. The existing overloads still throw `ArgumentException`.

### Fixes

- **Parse** (YANUnmanaged):
  - An out-of-range value (`"99999999999".Parse<int>()`, `int.MinValue.Abs()`) no longer crashes the process with a stack overflow. It returns the default (0, `null` or `defaultValue`), as the never-throw contract says.
  - `nint`/`nuint` are supported, and the type cache is thread-safe.
  - Invalid strings are parsed with `TryParse`: `"abc".Parse<int>()` takes 33 ns instead of 23 µs.
  - Fractional strings are floored exactly.
  - An input that already is a `T` is returned unchanged, so a `DateTime` keeps its milliseconds and `Kind`.
- **Collections**: the helpers no longer use unordered PLINQ, so results keep the input order. `ToImmutable*` of an empty non-generic collection no longer throws.
- **YANMath**:
  - Integer and decimal math is exact instead of going through `double`: `1.005m.Round(2)` is `1.01`, `long` sums keep every digit, and `3m.Pow(-1)` is exact.
  - `Round` accepts more than 15 digits, exactly.
  - Values at the type limits are exact: `long.MaxValue.Round()`, which crashed 8.3.3 with a stack overflow, returns `long.MaxValue`.
  - `Min` / `Max` / `Average` of all-`null` input return the default.
  - `Log2` uses `Math.Log2`.
  - Typed `Sum` / `Average` no longer box: `Sum<int>` over 1000 items takes 1 µs instead of 34 µs, with no allocation.
  - `Average` with a `decimal` result is exact when its running `decimal` sum overflows (it fell back to `double`): `YANMath.Average(decimal.MaxValue, decimal.MaxValue)` is `decimal.MaxValue`. `Sum` keeps the `double` fallback.
- **YANRandom**:
  - `NextDecimal()` is uniform over `[0, 1)`.
  - Ranges are half-open everywhere, including `NextUlong`, `NextDateTime` and rounding at the top of a range.
  - `NextDateTime` keeps ticks and `Kind`.
  - `NextNint` / `NextNuint` no longer crash.
  - `NextDouble(double.MinValue, double.MaxValue)` returns a finite value (it could return an infinity or `NaN`), and `NextDecimal(decimal.MinValue, decimal.MaxValue)` no longer throws `OverflowException`.
  - `GenerateRandom(min, max)` and `GenerateRandom<T>()` use `Random.Shared` instead of a new `Random` per value.
- **YANObject**:
  - Inherited properties are checked, and indexers and write-only properties are skipped.
  - `AllValidFields` with a blank name is `false` again, as in 8.3.2.
  - `Copy()` creates the runtime type, and throws `NotSupportedException` for a collection type instead of losing its items.
  - The per-type caches hold their types weakly (`ConditionalWeakTable`): a type of a collectible `AssemblyLoadContext` (a plugin) used with the property checks no longer keeps that context from unloading (8.3.3 cached their properties per type for the life of the process), and the caches added since 8.3.3 for the field-name checks, `Copy` and `ChangeTimeZoneAllProperty` do not keep it either.
  - `ChangeTimeZoneAllProperties` is eager and converts each object once.
  - `ChangeTimeZoneAllProperty`:
    - It handles cycles, deep graphs (a 1,000,000-node list), read-only collections, dictionaries and `ArraySegment<T>`.
    - It writes converted copies back in 8.3.3's order.
  - Property reads and copies use compiled accessors from the second call on: `IsNullDefault` on 6 properties takes 99 ns instead of 199 ns. The results and the type, message and `InnerException` of a getter or setter exception are those of reflection (apart from one `ForceInterpretedInvoke` case described on the YANObject wiki page), but the exception's `Source`, `TargetSite` and stack frames differ from the second call on (see *Behaviour changes* below).
- **YANExpression**: `PropertyExpression` calls a matching parameterless method correctly. Its cache key includes the parameter name, and it no longer throws for `new`-hidden properties. Its cache holds the types weakly, so a plugin type no longer keeps a collectible `AssemblyLoadContext` from unloading.
- **YANTask**:
  - Cancellation is observed while waiting: 114 ms instead of never.
  - Completion order is tracked in O(n): 16,000 tasks take 0.9 ms instead of 2.4 s, and no continuation is leaked.
  - A lazy task sequence is enumerated once.
- **YANProcess**:
  - A blank name no longer aborts the batch.
  - Every match is tried and every handle disposed, and the first failure is rethrown.
  - The calling process is skipped.
  - Names with a dot work.
  - All matches are signalled before any wait.
- **YANText**:
  - `FormatName` leaves single spaces and no trailing space.
  - The string `EqualsIgnoreCase` collection helpers use the same comparison as the scalar method and allocate nothing for arrays and lists (for `AnyEqualsIgnoreCase` / `AllNotEqualsIgnoreCase` up to 16 strings; larger inputs use a `HashSet`).
- **Snowflake**:
  - The constructor's `sequence` is honoured and validated.
  - `ExtractIdComponents` returns correct components.
  - `ExtractIdAlphabeticComponents` / `ExtractIdAlphanumericComponents` validate the ID string.
  - A clock rollback throws `InvalidOperationException`.
  - The wait for the next millisecond uses `SpinWait` (about 0.1 s of CPU instead of 2 s in a sequence-exhaustion test).

### Behaviour changes to check when upgrading

Each item changes a result, an exception or a side effect that code written against 8.3.3 can observe. Most before -> after values were measured with the same calls on 8.3.3 and 8.4.0; the YANProcess items and a few details (the `TimeSpan` and enum `ToString()` targets, `GetCallingAssembly`, a never-ending graph) come from the reviews, the tests and the wiki pages. Calls that crashed the process in 8.3.3 are listed under *Fixes* only.

**YANUnmanaged (Parse)**

- Fractional strings are floored exactly: `"2.9999999999999999".Parse<int>()` 3 -> 2, `"12345678901234567.9".Parse<long>()` 12345678901234600 -> 12345678901234567. See *Conversion Rules* on the YANUnmanaged wiki page.
- `nint` / `nuint` convert like `long` / `ulong`, as target and as input: `((object)5).Parse<nint>(0)` 0 -> 5, `"5".Parse<nint?>()` `null` -> 5, `"x".Parse<nint>("-77")` 0 -> -77, `((nint)5).Parse<int>()` 0 -> 5, `((nint)5).Parse<bool>()` `false` -> `true`.
- An input that already is a `T` is returned as is: `Animal a = new Dog(); a.IsDefault()` `true` -> `false`, `new object[] { dog }.ToList<Animal>()` `[null]` -> `[dog]`, and `Parse<object>()` of a `Dog`, `Guid`, `TimeSpan` or `nint` `null` -> the input.
- `DateTime` values keep their milliseconds and `Kind` (8.3.3 cut them to whole seconds, `Unspecified`): `dt.Parse<DateTime>()`, `dt.Parse<DateTime?>()` and a `DateTime` `defaultValue`. A `DateTime` input with a format is returned (was `DateTime.MinValue`), and `new DateTime(1, 1, 1, 0, 0, 0, 1).IsDefault()` `true` -> `false`.
- In the `defaultValue` overload, a `DateTime` string keeps its milliseconds (`"2025-01-02 03:04:05.678".Parse<DateTime>(d)` .000 -> .678), a string with `Z` or an offset gives `Kind` `Local`, as `DateTime.TryParse` does (was `Unspecified`), and `"bad".Parse<DateTime>(dt, "dd/MM/yyyy")` `DateTime.MinValue` -> `dt`.
- An input whose `ToString()` throws gives `null`, the default or `defaultValue` for string, `DateTime`, `Guid`, `TimeSpan` and enum targets; 8.3.3 let the exception escape.
- With a `format`, a default value of `Parse<DateTime>` that is not a `DateTime` (usually a string) is parsed with the format first and, if that fails, without it (current culture, or the provider of `ParseWith` / `ParsesWith`): `"bad".Parse<DateTime>("2025-01-01", "dd/MM/yyyy")` `DateTime.MinValue` -> 1 January 2025, also in `Parses`. A `DateTimeOffset` or `DateOnly` default whose text does not match the format gives the same result as without a format (was `DateTime.MinValue`). Only results that were `DateTime.MinValue` change.

**Collection helpers**

- The helpers that return a sequence (`Parses` and the `ToList` / `ToArray` / `ToImmutable*` conversions built on it, `Serializes` / `Deserializes`, the `YANText` and `YANDateTime` collection methods) are deferred, keep the input order and run on the enumerating thread; as in 8.3.3, the first item is read at the call (to return `null` for an empty input), so an iterator source is started twice. 8.3.3 used unordered PLINQ for 1,000 or more items, which changed the order and wrapped an exception from one item in an `AggregateException` (`Serializes` of 2,000 objects with a throwing getter); the exception now surfaces as itself. The in-place `List<T>` overloads still use `Parallel.For` for large lists, and `GenerateRandoms` still generates 1,000 or more values in parallel.

**YANMath**

- Integer and `decimal` results are exact instead of going through `double`: `1.005m.Round(2)` 1 -> 1.01, `1.10m.Round(2, MidpointRounding.ToPositiveInfinity)` 1.11 -> 1.1, `YANMath.Sum(new long[] { 9007199254740993, 0 })` ...992 -> ...993, `3L.Pow(39)` 4052555153018976256 -> 4052555153018976267, `3m.Pow(-1)` 0.333333333333333 -> 0.3333333333333333333333333333 (`decimal` results keep up to 28-29 significant digits instead of 15). Values at the type limits come back: `decimal.MaxValue.Round()` 0 -> `decimal.MaxValue`, `((object)long.MaxValue).Truncate<ulong>()` 9223372036854775808 -> 9223372036854775807.
- With an integer or `decimal` result, the object overloads convert a `double` or `float` through its shortest round-trip text, and a whole one exactly: `((object)1.005).Round<decimal>(2)` 1 -> 1.01, `YANMath.Sum<decimal>(0.1f, 0.2f)` 0.300000004470348 -> 0.3, `YANMath.Sum<int>(0.5, 1e-17)` 0 -> 1, `((object)1e23).Truncate<decimal>()` 100000000000000000000000 -> 99999999999999991611392, `((object)Math.Pow(2, 60)).Truncate<decimal>()` 1152921504606850000 -> 1152921504606846976.
- `Min` / `Max` / `Average` of all-`null` input return the default instead of throwing `InvalidOperationException`: `new List<int?> { null, null }.Min<int>()` is 0, `YANMath.Average<int?>(null, null)` is `null`. A typed `Average` over a sequence that is empty when enumerated again is 0 (threw).
- `Round` with 16 or more digits rounds instead of throwing `ArgumentOutOfRangeException`: `(0.1 + 0.2).Round(16)` is 0.3. Negative digits still throw. With 16 or more digits, an undefined `MidpointRounding` throws `ArgumentException` (`ParamName` `mode`) instead of `ArgumentOutOfRangeException` (`digits`).
- `Log2` uses `Math.Log2`: `536870912.0.Log2()` 29.000000000000004 -> 29. Other results can change in the last digit.
- The exact conversion costs time: `Sum` and `Average` with an integer or `decimal` result over boxed `double` values, or over a `double` collection with another result type (`doubles.Sum<decimal>()`), are several times slower. `YANMath.Sum<decimal>` over 1,000 boxed random doubles took about 0.58 ms instead of about 0.15 ms. Same-type typed calls (`YANMath.Sum<double>(doubles)`) are not affected.
- Typed `Average` / `Min` / `Max` over a `List<T>` subclass that re-implements `IEnumerable<T>` follow that enumeration, as typed `Sum` already did: for a list holding 5, -100 and 3 that enumerates 5 and 3, `Average` -31 -> 4 and `Min` -100 -> 3.
- When the running `decimal` sum of an `Average` overflows, all elements are added again, exactly (`BigInteger`, in one more pass over the collection, so an iterator source is started three times instead of twice), instead of falling back to the `double` average, and the mean is rounded as `decimal` division rounds: `YANMath.Average(decimal.MaxValue, decimal.MaxValue)` 0 -> `decimal.MaxValue`, `YANMath.Average(decimal.MaxValue, 1m, -decimal.MaxValue)` 0 -> 0.3333333333333333333333333333, `YANMath.Average<decimal>(new object[] { decimal.MaxValue, decimal.MaxValue, 1e20 })` 52818775042842900000000000000 -> 52818775042842891729029300223, `YANMath.Average<long>(new object[] { decimal.MaxValue, 3m, -decimal.MaxValue })` 0 -> 1. Averages whose sum does not overflow gave the same bits in a check of 4,012 inputs over every overload; an object element without a `decimal` value (`double.NaN`) still selects the `double` average (after an overflow, in a fourth pass), and `Sum` is unchanged.
- With an integer or `decimal` result (`int`, `long`, `decimal`, `int?` and `decimal?` were counted), the object `Average` overloads (`IEnumerable<object?>` and non-generic `IEnumerable`) over a collection with an element that has no `decimal` value (`double.NaN`) start an iterator source three times instead of twice also when nothing overflows (the emptiness check, the `decimal` pass and the `double` pass); with a `double` result they still start it twice.

**YANRandom**

- Ranges are half-open and uniform: `NextUlong(5, 6)` returned 5 or 6 (and was modulo-biased), now always 5; `NextDateTime(min, max)` could return `max` and now returns whole ticks in `[min, max)` with the `Kind` of `min` (was `Unspecified`); `NextSingle` / `NextDouble` / `NextDecimal` never return `max`, also not through rounding (`NextDecimal(1e28m, 1e28m + 1)` returned `max` about half the time, now always `min`). A call without bounds never returns the type's `MaxValue`.
- `NextDecimal()` is uniform over `[0, 1)`; 8.3.3 put 96% of its values between 0.1 and 0.792.
- A seeded `Random` gives different values from `NextDecimal` (with or without bounds), `NextUlong` and `NextDateTime`. `NextInt`, `NextLong`, `NextByte`, `NextDouble` and `NextSingle` gave the same values as 8.3.3 in a check with `new Random(42)`.
- `GenerateRandom<char>(min, max)` with `object` bounds and `GenerateRandoms<char>(min, max, size)` return a `char` in `[min, max)`, or `a`-`z` when both bounds are `null` (they returned `'\0'`).
- After recompiling: `GenerateRandom<T>(a, b)` with two typed numeric, `DateTime` or `char` arguments binds to the new range overload and returns a value in `[a, b)` (8.3.3 bound to `params T[]`: 2,000 calls of `GenerateRandom<int>(1, 100)` gave only 1 and 100); `bool`, enum and `Guid` pairs still return one of the two. A two-bound call with named arguments, such as `GenerateRandom<Guid>(min: a, max: b)`, returned `Guid.Empty` (the enum's zero value, a random `bool`) and now returns `a` or `b`. Binaries compiled against 8.3.3 keep the old binding until rebuilt.

**YANObject**

- The property checks (`IsNullDefault`, `IsNotNullDefault`, `AllProperties*`, `AnyProperties*`) see inherited properties: `new Derived { BaseName = "x" }.IsNullDefault()` `true` -> `false`. Every array (`Rank`) and every exception (`Message`) is no longer null-default (`Array.Empty<int>().IsNullDefault()` `true` -> `false`), and an inherited getter that throws now surfaces as `TargetInvocationException` (8.3.3 never called it).
- A struct property is compared with `default(T)`, not with an instance made by its parameterless constructor.
- `AllPropertiesDefault(names)`, `AllPropertiesDefaults(names)` and `AllPropertiesNotDefaults(names)` return `false` when no name matches a property (were `true`). `AllPropertiesDefaults` / `AllPropertiesNotDefaults` return `false` for a collection that contains `null` (a `null` element satisfied both).
- Field names: blank names are never valid, as in 8.3.2 (`["Name", null].AllValidFields<User>()` `true` -> `false`; `IsNotValidField` of `null`, `""` or whitespace `false` -> `true`; `["Name", null].AnyNotValidField<User>()` `false` -> `true`). The indexer `"Item"` and write-only properties are no longer valid fields, and a `new`-hidden property is valid (threw `AmbiguousMatchException`).
- `Copy()`: `Base b = new Derived(); b.Copy()` returns a `Derived` made with `Derived`'s constructor (8.3.3 threw `TargetException` when `Derived` adds a settable property, and otherwise returned a `Base`). Structs and `DateTime` values are copied (`5.Copy()` 0 -> 5).
- `Copy()` of a class that implements `IList` (arrays included), `IDictionary`, `ICollection` or `ICollection<T>` throws `NotSupportedException`, before any constructor runs, since only properties are copied: `new List<int> { 1, 2 }.Copy()` and the other types with an indexer threw `TargetParameterCountException`; `new HashSet<int> { 1, 2 }.Copy()`, `LinkedList<T>`, `SortedSet<T>` and other `ICollection<T>` types without an indexer returned a copy without the items (their settable properties copied); an `int[]` or a `ReadOnlyCollection<T>` typed as `object` returned a new `object`. Of the classes that implement only the non-generic `ICollection`, `Queue<T>`, `Stack<T>`, `ConcurrentQueue<T>`, `ConcurrentStack<T>`, `ConcurrentBag<T>`, `BlockingCollection<T>` and the non-generic `Queue` and `Stack` returned an empty collection (typed as `object`, a new `object`), and `NameValueCollection`, `WebHeaderCollection` and a `BitArray` typed as `object` threw `TargetParameterCountException`. Use the collection's copy constructor or `ToList` / `ToArray` / `ToDictionary`. A class that implements only `IEnumerable`, `IEnumerable<T>` or `IReadOnlyCollection<T>` (`StringDictionary`, which threw `TargetParameterCountException`, now returns an empty one) and `PriorityQueue<TElement, TPriority>` are still copied without their items.
- From a property's second read by the property checks, or its second copy by `Copy`, a getter or setter exception still arrives as a `TargetInvocationException` with the same type, message and `InnerException`, but its `Source` is `YANLib.Implementation` (was `System.Private.CoreLib`), its `TargetSite` is `PropertyReader.GetValue` or `PropertyCopier.Copy`, and the stack frames differ; `Assembly.GetCallingAssembly()` in such a getter can return `Anonymously Hosted DynamicMethods Assembly` (seen for value-type properties; for a reference-type property the JIT usually tail-calls the getter and it still returns `YANLib.Implementation`).
- `ChangeTimeZoneAllProperties` runs at once and returns an array: with the result ignored, 8.3.3 converted nothing, and enumerating its lazy result twice shifted the objects twice (+14 h). An object listed twice or shared by several elements is shifted once.
- `ChangeTimeZoneAllProperty` converts more: an object reached through two references is shifted once (was twice); getter-only lists, arrays and dictionaries, `DateTime` items of `object` lists and arrays, `DateTime?` items of lists and arrays, and `Dictionary<TKey, DateTime>` values are converted (8.3.3 left them unchanged, or threw `TargetParameterCountException` for the dictionary).
- `ChangeTimeZoneAllProperty` calls fewer setters. 8.3.3 set every readable and writable property with a non-null value (strings, numbers, objects with nothing to convert) and every non-null item of a list (an `ObservableCollection<T>` raised a `Replace` event for each item). Now only `DateTime` properties and values in which a `DateTime` was converted are written back, so a read-only `CultureInfo` property or another throwing setter on such a value no longer fails the walk. A throwing getter is skipped.
- `ChangeTimeZoneAllProperty` reads getters differently: getter-only list, array and dictionary properties are now called (so a `Lazy<T>.Value` read inside such a getter runs its factory), and an `IList` item is read once instead of twice, plus the list's `IsReadOnly` and one more `Count`.
- `ChangeTimeZoneAllProperty` leaves unchanged the `DateTime` properties of classes derived from the framework types it does not walk into (`StringWriter` and other `TextWriter`s, `CancellationTokenSource`, `Task`, `Stream`, ...): with `(0, 7)`, `class LogWriter : StringWriter { public DateTime Started { get; set; } }` keeps 10:00, where 8.3.3 gave 17:00.
- `ChangeTimeZoneAllProperty` shifts some values twice (`(0, 7)` turns 10:00 into 00:00 the next day): a field behind both a getter-only list, array or dictionary property and a writable copy getter (`List<DateTime> View => _d;` with `List<DateTime> Copy { get => _d.ToList(); set => _d = value; }`; 8.3.3 gave 17:00), and the values of a type that implements `IList<DateTime?>` or `IDictionary<TKey, DateTime>` and has a writable property returning the collection behind it or a copy of its values (8.3.3 converted them once, left them unchanged or threw `TargetParameterCountException`, depending on the shape). See *Changes since 8.3.3* on the YANObject wiki page.
- A getter-only list property that builds new objects on every call, of a type that leads back to itself, now makes `ChangeTimeZoneAllProperty` run until memory runs out; 8.3.3 skipped getter-only properties and returned.

**YANExpression**

- `PropertyExpression<T>("p", name)` with the name of a parameterless method builds a call (`p => p.Describe()`; 8.3.3 built a constant `System.Reflection.RuntimeMethodInfo` type), and throws `ArgumentException` for a `void`, by-ref, by-ref-like or generic method.
- The cache key includes the parameter name: `("x", "Name")` followed by `("u", "Name")` returned `x => x.Name`, now `u => u.Name`.

**YANTask**

- `WaitAnyWithCondition` / `WhenAnyWithCondition` observe a cancellation while waiting: the returned task is canceled promptly and awaiting it throws `OperationCanceledException`. 8.3.3 noticed the token only when a task completed, so with tasks that never complete it waited forever. A token that is already canceled still gives `TaskCanceledException`.
- A lazy task sequence is enumerated once; 8.3.3 enumerated it twice, so an iterator that creates tasks ran twice.
- The streaming `WaitAnyWithConditions` / `WhenAnyWithConditions` (internal in 8.3.3) throw `OperationCanceledException` in every cancellation case, including a token that is already canceled when the enumeration starts, also for a `null` or empty task collection: that is not an empty enumeration. A `null` predicate throws `ArgumentNullException` (`ParamName` `predicate`) from the first `MoveNextAsync`. The single-result methods still count a `null` predicate as no match.

**YANProcess**

- The existing `KillAllProcessesByName` / `KillAllProcessesByNames` signal every matching process before waiting for any (8.3.3 killed and awaited each in turn), so a process that does not exit no longer delays the others.
- A `null` or blank name in `KillAllProcessesByNames` is skipped and the other names are processed (8.3.3 killed nothing). A name that leaves no file name (`"dir/"`, `".exe"`) kills nothing; 8.3.3 passed `""` to `Process.GetProcessesByName`, which matches every process.
- The calling process is skipped (8.3.3 threw `InvalidOperationException` when it matched). A name with a dot (`"my.app"`) is looked up as given first and without its extension only if nothing matches; 8.3.3 always stripped it to `"my"`.
- When one kill fails, the other matches are still killed and every handle is disposed, then the first failure is rethrown with its original type; 8.3.3 stopped at the first failure.

**YANText**

- `FormatName` leaves single spaces and no trailing space: `"john ,doe"` `"John  Doe"` -> `"John Doe"`, `"John."` `"John "` -> `"John"`; tabs become one space, and punctuation-only input gives `""`.
- The string `AllEqualsIgnoreCase`, `AnyEqualsIgnoreCase`, `AllNotEqualsIgnoreCase` and `AnyNotEqualsIgnoreCase` compare with `StringComparison.OrdinalIgnoreCase`, like the scalar `EqualsIgnoreCase`, instead of comparing `ToLowerInvariant` copies: `new[] { "\u212A", "k" }.AllEqualsIgnoreCase()` (the Kelvin sign and `k`) `true` -> `false`.
- `CleanSpace`, `FilterAlphabetic`, `FilterNumber` and `FilterAlphanumeric` return the input instance itself when nothing changes.

**Snowflake**

- `IdGenerator.NextId*` throws `ArgumentOutOfRangeException` (`ParamName` `timestampEpoch`) when `timestampEpoch` is later than now, or 2^41 ms (about 69.7 years) or more before it. 8.3.3 returned a negative or wrapped ID from `NextId`, and its string forms threw `IndexOutOfRangeException` for a future epoch. A failing call uses up no sequence number.
- `ExtractIdComponents` (and the string variants) read the timestamp field unsigned, so an ID made 2^40 ms (about 34.8 years) or more after its epoch decodes correctly: 8.3.3 decoded an ID of `NextId(0L)` (the Unix epoch) to 1957. Such an ID is negative; `NextIdAlphabetic(0L)` / `NextIdAlphanumeric(0L)` encode it as an unsigned 64-bit value (8.3.3 threw `IndexOutOfRangeException`).
- The constructor's `sequence` is validated (`new IdGenerator(1, 1, 8192)` throws `ArgumentOutOfRangeException`, `ParamName` `sequence`) and used for the first ID (8.3.3 accepted any value and started at 0).
- The `sequence` argument of the `Extract*Components` methods is ignored; 8.3.3 subtracted it, in milliseconds, from the timestamp.
- `ExtractIdAlphabeticComponents` / `ExtractIdAlphanumericComponents` throw `ArgumentNullException` for `null` (was `NullReferenceException`) and `ArgumentException` (`ParamName` `id`) for an empty, lower-case, foreign-character or larger-than-64-bit string; 8.3.3 returned meaningless components (`"abc"` decoded to 2022-12-31).
- A clock rollback throws `InvalidOperationException` instead of `System.Exception`; `catch (Exception)` still catches it.
- When the sequences of a millisecond are used up, `SpinWait` uses much less CPU but lowers the peak rate: 16,000 IDs with `BitAllocationStrategy.MoreDistributed` took about 2.2 s instead of 2.0 s (about 0.1 s of CPU instead of 2.0 s).

### Source compatibility notes

- The new overloads of `NextChar` and `KillAllProcessesByName` remove the natural delegate type of these method groups, so `var f = random.NextChar;` or `Delegate d = YANProcess.KillAllProcessesByName;` now gives CS8917; use a typed delegate (`Func<char> f = random.NextChar;`).
- `GenerateRandom<T>(a, b)` with two typed arguments binds to the new range overload when recompiled (see *YANRandom* above).
- `ParseWith` / `ParsesWith` are new extension names: a project that already has its own `ParseWith` / `ParsesWith` extension on `object` or `IEnumerable` in an imported namespace may now get CS0121.
- `IsNull()` / `IsNotNull()` compile again, with an obsolete warning (CS0618).
- A call that passes `sequence` to `ExtractIdComponents`, `ExtractIdAlphabeticComponents` or `ExtractIdAlphanumericComponents` with a `BitAllocationStrategy` (`ExtractIdComponents(id, strategy, epoch, 0)`, `ExtractIdComponents(id, strategy, sequence: 0)`) gets an obsolete warning (CS0618), an error with warnings as errors; leave `sequence` out. Calls without it, and all calls of the overloads with custom bit counts, bind as before or to the new overload with the same result.
- The `onDuplicate` overloads remove the natural delegate type of `dict.Parses<int, string>`, `YANEnumerable.ToDictionary<...>`, `ToImmutableDictionary<...>` and `ToImmutableSortedDictionary<...>` with all type arguments given, so `var f = dict.Parses<int, string>;` now gives CS8917; typed delegates and `Assert.Throws<ArgumentException>(dict.Parses<int, string>)` bind as before (checked with C# 12, 13 and 14).
- The public API is otherwise a superset of 8.3.3; package validation against 8.3.3 passes.

### Packaging and tooling

- The package ships `YANLib.xml` (IntelliSense) and no longer adds a `favicon.ico` content file to consuming projects. `YANLib.dll` no longer embeds a Win32 icon.
- The package's project URL is https://github.com/Tynab/YANLib, and its description says .NET 8 (LTS).
- A clean `dotnet pack` works, and `dotnet pack` validates the API against 8.3.3.
- Restore uses nuget.org only.
- The test project no longer references the benchmark console (`console/YANLib.Benchmarks`): `ConcurrentCollectionTests` builds its own data, so BenchmarkDotNet is no longer part of the test build.
- README.md, the package readme, no longer ends with an 'Important Notes' block about Elastic.Apm, DotNetCap.CAP and ABP / Entity Framework layers, which came from another project.
- The debugger can step into `YANLib.Implementation`; the public facade and the Snowflake `IdGenerator` (which lives in `YANLib.dll`) stay hidden.
- `.editorconfig` now describes the code style and is checked by `dotnet format --verify-no-changes`. New: the CI workflow (it pins the .NET 8 SDK with a `global.json` it writes itself, so contributors can use any SDK), a Publish workflow (pushing a tag such as `v8.4.0` runs CI and pushes the matching package to nuget.org; it needs the repository secret `NUGET_API_KEY`) and `ROADMAP.md`.
