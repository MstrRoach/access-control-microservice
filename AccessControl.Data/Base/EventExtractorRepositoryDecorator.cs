using AccessControl.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Data.Base;


/// <summary>
/// Clase base para almacenar las entidades de dominio y asegurarse de
/// distribuir los eventos internos
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class EventExtractorRepositoryDecorator<T> : IRepository<T>
    where T : IAggregate
{
    /// <summary>
    /// Repositorio interno que contiene las lecturas
    /// y escrituras
    /// </summary>
    private readonly IRepository<T> _inner;

    /// <summary>
    /// Bus de eventos para distribuir los eventos generados por
    /// las entidades de dominio
    /// </summary>
    //private readonly IEventBus _eventBus;

    /// <summary>
    /// Constructor para el decorador
    /// </summary>
    /// <param name="inner"></param>
    /// <param name="eventBus"></param>
    public EventExtractorRepositoryDecorator(IRepository<T> inner/*, IEventBus eventBus*/)
    {
        _inner = inner;
        //_eventBus = eventBus;
    }

    /// <summary>
    /// Ejecuta la creacion y despues extraeee los eventos para
    /// distribuirlos a traves deel bus dee eevntos
    /// </summary>
    /// <param name="aggregate"></param>
    /// <returns></returns>
    public async Task<T> Save(T aggregate)
    {
        var result = await _inner.Save(aggregate);
        DispatchEvents(aggregate);
        return result;
    }

    public async Task Delete(T aggregate)
    {
        await _inner.Delete(aggregate);
        DispatchEvents(aggregate);
    }

    /// <summary>
    /// Obtiene un eelemento que concida con la especificacion
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<T> Get(object specification)
        => await _inner.Get(specification);


    /// <summary>
    /// Obtiene una lista dee entiddades que coincideen con 
    /// la especificacion
    /// </summary>
    /// <returns></returns>
    public async Task<List<T>> GetAll(object specification)
        => await _inner.GetAll(specification);

    /// <summary>
    /// Indica si existe algun registro que coincida con la especificacion
    /// </summary>
    /// <param name="specification"></param>
    /// <returns></returns>
    public Task<bool> Exist(object specification)
        => _inner.Exist(specification);

    /// <summary>
    /// Realiza el conteo de los registros que coincidan con la
    /// especificacion pasada por parametro
    /// </summary>
    /// <param name="specification"></param>
    /// <returns></returns>
    public Task<int> Count(object specification)
        => _inner.Count(specification);


    /// <summary>
    /// Actualiza un reeegistro deel agregado dentro
    /// del reepositorio y distribuye los eventos
    /// </summary>
    /// <param name="aggregate"></param>
    /// <returns></returns>
    public async Task<T> Update(T aggregate)
    {
        var result = await _inner.Update(aggregate);
        DispatchEvents(aggregate);
        return result;
    }

    /// <summary>
    /// Distribuye todos los eveentos dee domminio que esten dentro
    /// de la eentidad
    /// </summary>
    /// <param name="aggregate"></param>
    private void DispatchEvents(T aggregate)
    {
        // Distribuimos los eventos
        foreach (var @event in aggregate.DomainEvents)
        {
            //_eventBus.Publish(@event).ConfigureAwait(false).GetAwaiter().GetResult();
            Console.WriteLine("Event raised");
        }
        // Los eliminamos
        aggregate.ClearDomainEvents();
    }
}