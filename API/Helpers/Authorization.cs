namespace API.Helpers;

public class Authorization
{
    public enum Roles
    {
        Administrador,
        Vendedor
    }

    public const Roles rolDefault = Roles.Vendedor;
}
