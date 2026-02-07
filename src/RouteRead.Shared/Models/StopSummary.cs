namespace RouteRead.Shared.Models;

public sealed record StopSummary(string Id, string RouteId, string Name, string Address, string? LastReading);