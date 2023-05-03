using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Domain.Base;

/// <summary>
/// Interface para definir los eventos de dominio
/// </summary>
public interface IDomainEvent
{
    /// <summary>
    /// Id del evento de dominio
    /// </summary>
    Guid Id { get; }

    /// <summary>
    /// Fecha en la que ocurrio el evento
    /// </summary>
    DateTime OccurredOn { get; }
}
