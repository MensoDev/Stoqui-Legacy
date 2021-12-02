namespace Stoqui.Stock.Application.Interfaces.Models;

public record ProductStockModel (
    Guid Id, 
    string Name, 
    int ActiveStock, 
    int RepairStock, 
    int TrashStock, 
    DateTime RegistrationDate);