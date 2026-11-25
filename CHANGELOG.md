# Changelog

## 8.4.0

A large maintenance release. Every change was made against the 8.3.3 sources, checked by independent reviews, and is covered by tests (2186 tests, 0 failures) and by CI (build with warnings as errors, format check, the whole test suite and package validation against 8.3.3 on every push). The wiki pages have a *Changes since 8.3.3* section where the details matter. Design questions that were not changed in 8.x are listed in [ROADMAP.md](ROADMAP.md).

### New API

- **Parse with a culture**: `ParseWith<T>(IFormatProvider?)` and `ParsesWith<T>(...)` (9 overloads) parse with the given provider; `Parse` / `Parses` keep using the current culture. Under `vi-VN`, `"1.5".ParseWith<double>(CultureInfo.InvariantCulture)` is `1.5`.
- **Random**: `GenerateRandom<T>(T min, T max)` returns a value in `[min, max)` for the numeric types, `DateTime` and `char` (calls such as `GenerateRandom<int>(18, 80)` used to bind to `params T[]` and return one of the two arguments), and `Random.NextChar(char min, char max)`.
- **YANTask**: `WaitAnyWithConditions` / `WhenAnyWithConditions` are public. They stream every matching result in completion order, and every cancellation throws `OperationCanceledException`.
- **YANProcess**: overloads of `KillAllProcessesByName` / `KillAllProcessesByNames` take `bool entireProcessTree` (the existing methods keep killing the whole tree) and a `CancellationToken`; use `new CancellationTokenSource(TimeSpan)` for a timeout.
- **YANObject**: `IsNull()` / `IsNotNull()`, removed in 8.3.3 by mistake, are back as `[Obsolete]` shims with their 8.3.2 signatures. Use `is null` / `is not null`.

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
  - `Min` / `Max` / `Average` of all-`null` input return the default.
  - `Log2` uses `Math.Log2`.
  - Typed `Sum` / `Average` no longer box: `Sum<int>` over 1000 items takes 1 µs instead of 34 µs, with no allocation.
- **YANRandom**:
  - `NextDecimal()` is uniform over `[0, 1)`.
  - Ranges are half-open everywhere, including `NextUlong`, `NextDateTime` and rounding at the top of a range.
  - `NextDateTime` keeps ticks and `Kind`.
  - `NextNint` / `NextNuint` no longer crash.
- **YANObject**:
  - Inherited properties are checked, and indexers and write-only properties are skipped.
  - `AllValidFields` with a blank name is `false` again, as in 8.3.2.
  - `Copy()` creates the runtime type.
  - `ChangeTimeZoneAllProperties` is eager and converts each object once.
  - `ChangeTimeZoneAllProperty`:
    - It handles cycles, deep graphs (a 1,000,000-node list), read-only collections, dictionaries and `ArraySegment<T>`.
    - It writes converted copies back in 8.3.3's order.
  - Property reads and copies use compiled accessors from the second call on: `IsNullDefault` on 6 properties takes 99 ns instead of 199 ns. The exceptions stay those of reflection.
- **YANExpression**: `PropertyExpression` calls a matching parameterless method correctly. Its cache key includes the parameter name, and it no longer throws for `new`-hidden properties.
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
  - The string `EqualsIgnoreCase` collection helpers use the same comparison as the scalar method and allocate nothing for arrays and lists.
- **Snowflake**:
  - The constructor's `sequence` is honoured and validated.
  - `ExtractIdComponents` returns correct components.
  - The `FromBase*` methods validate their input.
  - A clock rollback throws `InvalidOperationException`.
  - The wait for the next millisecond uses `SpinWait` (about 0.1 s of CPU instead of 2 s in a sequence-exhaustion test).

### Behaviour changes to check when upgrading

- `IdGenerator.NextId*` throws `ArgumentOutOfRangeException` when `timestampEpoch` is later than now, or 2^41 ms (about 69.7 years) or more before it. 8.3.3 returned a negative or wrapped ID.
- `ExtractIdComponents` reads the timestamp field unsigned, so an ID made 2^40 ms or more after its epoch decodes correctly.
- `GenerateRandom<T>(a, b)` with two typed numeric, `DateTime` or `char` arguments now returns a value in `[a, b)` instead of `a` or `b`.
- `IsNullDefault` and the `AllProperties*` / `AnyProperties*` checks now see inherited properties. Every array is no longer null-default (it has `Rank`).
- The collection helpers that return a sequence are lazy, keep the input order and no longer run in parallel (the in-place `List<T>` overloads still use `Parallel.For` for large lists). `ChangeTimeZoneAllProperties` runs at once.
- Parse: exact floor of fractional strings (`"2.9999999999999999".Parse<int>()` is 2). See *Conversion Rules* on the YANUnmanaged wiki page.

### Source compatibility notes

- The new overloads of `NextChar` and `KillAllProcessesByName` remove the natural delegate type of these method groups, so `var f = random.NextChar;` or `Delegate d = YANProcess.KillAllProcessesByName;` now gives CS8917; use a typed delegate (`Func<char> f = random.NextChar;`).
- The public API is otherwise a superset of 8.3.3; package validation against 8.3.3 passes.

### Packaging and tooling

- The package ships `YANLib.xml` (IntelliSense) and no longer adds a `favicon.ico` content file to consuming projects.
- A clean `dotnet pack` works, and `dotnet pack` validates the API against 8.3.3.
- Restore uses nuget.org only.
- The debugger can step into `YANLib.Implementation`; only the thin public facade stays hidden.
- New: `.editorconfig` (checked by `dotnet format --verify-no-changes`), `global.json` (.NET 8 SDK), the CI workflow and `ROADMAP.md`.
