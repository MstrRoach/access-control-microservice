﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Domain.Base;

/// <summary>
/// Clase que implementa la interface para evento de dominio 
/// que implementa las variables minimas para el evento
/// </summary>
public class DomainEvent : IDomainEvent
{
    /// <summary>
    /// Id del evento
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Fecha en la que ocurre el evento
    /// </summary>
    public DateTime OccurredOn { get; }

    /// <summary>
    /// Constructor del evento base
    /// </summary>
    public DomainEvent()
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
    }
}