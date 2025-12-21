using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using AgentGateway.Core;

namespace AgentGateway.Adapters;

[ModelProvider("ollama", "Ollama", ProviderCapabilities.Chat | ProviderCapabilities.Streaming, "none")]
public sealed class OllamaAdapter : IChatClient, IModelCatalog
{
    public OllamaAdapter(IConfiguration cfg) { }

    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> chatMessages, ChatOptions? options = null, CancellationToken cancellationToken = default)
        => Task.FromResult(new ChatResponse(new ChatMessage(ChatRole.Assistant, "Ollama stub response.")));

    public IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> chatMessages, ChatOptions? options = null, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<ModelInfo>> ListModelsAsync(CancellationToken ct = default)
        => Task.FromResult<IReadOnlyList<ModelInfo>>(new[] { new ModelInfo("llama3.2", ProviderCapabilities.Chat | ProviderCapabilities.Streaming, new Dictionary<string, string>()) });

    public void Dispose() { }
    public object? GetService(Type serviceType, object? serviceKey = null) => null;
}
