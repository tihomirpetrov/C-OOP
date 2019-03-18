namespace MilitaryElite.Interfaces
{
    using System.Collections.Generic;

    public interface ILieutenantGeneral : IPrivate
    {
        ICollection<IPrivate> Privates { get; set; } 
    }
}