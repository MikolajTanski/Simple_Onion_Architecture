﻿namespace Simple_Onion_Architecture.Domain.Entities.Common;

public interface IEntity
{
    DateTime CreatedDate { get; set; }
    DateTime? ModifiedDate { get; set; }
}