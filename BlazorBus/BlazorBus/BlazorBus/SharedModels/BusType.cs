﻿namespace BlazorBus.SharedModels
{
  public enum BusType { Unknown = 0, BusMaster, RigBus, VirtualRigBus, LogBus, RotoBus, ClusterBus, UI }
  public class BusMasterGroups
  {
    public readonly string UI = "ui";
    public readonly string Radio = "radio";
    public readonly string Logging = "logging";
    public readonly string DxCluster = "dxcluster";
    public readonly string Rotor = "rotor";
  }
}