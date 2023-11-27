using System.ComponentModel.DataAnnotations;

namespace Server.Domain.Entities;

public abstract class BaseEntity<TIdentity>
{
    [Key]
    public TIdentity Id { get; set; }
}