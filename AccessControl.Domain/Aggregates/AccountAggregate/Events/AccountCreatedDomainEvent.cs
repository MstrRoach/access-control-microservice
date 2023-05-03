using AccessControl.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Domain.Aggregates.AccountAggregate.Events;

internal class AccountCreatedDomainEvent : DomainEvent
{
    public Guid AccountId { get; set; }

    public AccountCreatedDomainEvent(Guid accountId)
    {
        this.AccountId = accountId;
    }
}
