
namespace ReserveAqui.Core.Common;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTimeOffset? DataCriacao { get; set; }
    public DateTimeOffset? DataModificacao { get; set; }
    public DateTimeOffset? DataExclusao { get; set; }
}
