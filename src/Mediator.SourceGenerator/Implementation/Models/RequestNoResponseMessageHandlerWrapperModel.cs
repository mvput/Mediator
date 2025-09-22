namespace Mediator.SourceGenerator;

internal sealed record RequestNoResponseMessageHandlerWrapperModel : IRequestMessageHandlerWrapperModel
{
    public RequestNoResponseMessageHandlerWrapperModel(string messageType, CompilationAnalyzer analyzer)
    {
        FullNamespace = $"global::{analyzer.MediatorNamespace}.Internals";
        MessageType = messageType;
        TypeName = $"{messageType}NoResponseHandlerWrapper";
        TypeNameWithGenericParameters = $"{messageType}NoResponseHandlerWrapper<TRequest>";
        InterfaceTypeNameWithGenericParameter = $"I{messageType}NoResponseHandlerBase";
    }

    public string FullNamespace { get; }
    public string MessageType { get; }
    public string TypeName { get; }
    public bool IsStreaming => false;
    public string TypeNameWithGenericParameters { get; }
    public bool IsNoResponse { get; } = true;
    public string InterfaceTypeNameWithGenericParameter { get; }

    public string MessageHandlerDelegateName =>
        IsStreaming ? $"global::Mediator.StreamHandlerDelegate<TRequest, TResponse>"
        : IsNoResponse ? "global::Mediator.MessageHandlerDelegate<TRequest>"
        : $"global::Mediator.MessageHandlerDelegate<TRequest, TResponse>";
    public string PipelineHandlerTypeName =>
        IsStreaming ? "global::Mediator.IStreamPipelineBehavior<TRequest, TResponse>"
        : IsNoResponse ? "global::Mediator.IPipelineBehavior<TRequest>"
        : "global::Mediator.IPipelineBehavior<TRequest, TResponse>";

    public string ReturnTypeName =>
        IsStreaming ? "global::System.Collections.Generic.IAsyncEnumerable<TResponse>"
        : IsNoResponse ? "global::System.Threading.Tasks.ValueTask"
        : "global::System.Threading.Tasks.ValueTask<TResponse>";
    public string ReturnTypeNameWhenObject =>
        IsStreaming ? "global::System.Collections.Generic.IAsyncEnumerable<object?>"
        : IsNoResponse ? "global::System.Threading.Tasks.ValueTask"
        : "global::System.Threading.Tasks.ValueTask<object?>";
    public string HandlerBase => IsStreaming ? "IStreamMessageHandlerBase" : "IMessageHandlerBase";

    public bool Equals(IRequestMessageHandlerWrapperModel other)
    {
        return base.Equals(other);
    }
}
