namespace RoutingApp;

public interface IBookActivityRouter
{
    string GetOperation(RouterParameters parameters);
}