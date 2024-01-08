namespace YANLib.Benchmarks.Process.Common;

public class HttpBenchmark
{
    private HttpClient? _httpClient;

    [Params(1_000, 10_000, 100_000, 1_000_000)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup() => _httpClient = new HttpClient();

    [Benchmark]
    public async ValueTask<string> FetchUrl() => await _httpClient!.GetStringAsync("https://dev-api-support.hoozing.com/api/hoozing-support/agency-property-assignments/get-by-agent-id?agentId=0c4dec3a-c421-4a51-b94d-201fa9125256");
}
