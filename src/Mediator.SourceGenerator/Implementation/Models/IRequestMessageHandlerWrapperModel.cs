namespace Mediator.SourceGenerator
{
    internal interface IRequestMessageHandlerWrapperModel : IEquatable<IRequestMessageHandlerWrapperModel>
    {
        string FullNamespace { get; }
        string HandlerBase { get; }
        string InterfaceTypeNameWithGenericParameter { get; }
        bool IsNoResponse { get; }
        bool IsStreaming { get; }
        string MessageHandlerDelegateName { get; }
        string MessageType { get; }
        string PipelineHandlerTypeName { get; }
        string ReturnTypeName { get; }
        string ReturnTypeNameWhenObject { get; }
        string TypeName { get; }
        string TypeNameWithGenericParameters { get; }
    }
}
