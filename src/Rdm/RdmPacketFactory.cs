using Haukcode.ArtNet.Rdm.Packets.Net;
using Haukcode.ArtNet.Rdm.Packets.DMX;
using Haukcode.ArtNet.Rdm.Packets.Product;
using Haukcode.ArtNet.Rdm.Packets.Parameters;
using Haukcode.ArtNet.Rdm.Packets.Control;
using Haukcode.ArtNet.Rdm.Packets.Status;
using Haukcode.ArtNet.Rdm.Packets.Power;
using Haukcode.ArtNet.Rdm.Packets.Discovery;
using Haukcode.ArtNet.Rdm.Packets.Configuration;

namespace Haukcode.ArtNet.Rdm;

public class RdmPacketFactory
{
    public RdmPacketFactory()
    {
        RegisterDiscoveryMessages();
        RegisterStatusMessages();
        RegisterCoreMessages();
        RegisterRdmNetMessages();
        RegisterProductMessages();
        RegisterDmxMessages();
        RegisterDimmerMessages();
        RegisterPowerMessages();
        RegisterConfigurationMessages();
        RegisterControlMessages();
    }

    private void RegisterDiscoveryMessages()
    {
        RegisterPacketType(RdmCommands.Discovery, RdmParameters.DiscoveryUniqueBranch, () => new DiscoveryUniqueBranch.Request());
        RegisterPacketType(RdmCommands.DiscoveryResponse, RdmParameters.DiscoveryUniqueBranch, () => new DiscoveryUniqueBranch.Reply());

        RegisterPacketType(RdmCommands.Discovery, RdmParameters.DiscoveryMute, () => new DiscoveryMute.Request());
        RegisterPacketType(RdmCommands.DiscoveryResponse, RdmParameters.DiscoveryMute, () => new DiscoveryMute.Reply());

        RegisterPacketType(RdmCommands.Discovery, RdmParameters.DiscoveryUnMute, () => new DiscoveryMute.Request());
        RegisterPacketType(RdmCommands.DiscoveryResponse, RdmParameters.DiscoveryUnMute, () => new DiscoveryMute.Reply());

    }

    private void RegisterStatusMessages()
    {
        //QueuedMessage
        RegisterPacketType(RdmCommands.Get, RdmParameters.QueuedMessage, () => new QueuedMessage.Get());

        //StatusMessage
        RegisterPacketType(RdmCommands.Get, RdmParameters.StatusMessage, () => new StatusMessage.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.StatusMessage, () => new StatusMessage.GetReply());

        //ClearStatusId
        RegisterPacketType(RdmCommands.Set, RdmParameters.ClearStatusId, () => new ClearStatusId.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.ClearStatusId, () => new ClearStatusId.SetReply());
    }

    private void RegisterCoreMessages()
    {
        //SupportedParameters
        RegisterPacketType(RdmCommands.Get, RdmParameters.SupportedParameters, () => new SupportedParameters.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.SupportedParameters, () => new SupportedParameters.GetReply());

        //ParameterDescription
        RegisterPacketType(RdmCommands.Get, RdmParameters.ParameterDescription, () => new ParameterDescription.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.ParameterDescription, () => new ParameterDescription.GetReply());
    }



    private void RegisterRdmNetMessages()
    {
        //Endpoint List
        RegisterPacketType(RdmCommands.Get, RdmParameters.EndpointList, () => new EndpointList.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.EndpointList, () => new EndpointList.Reply());

        //EndpointListChange
        RegisterPacketType(RdmCommands.Get, RdmParameters.EndpointListChange, () => new EndpointListChange.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.EndpointListChange, () => new EndpointListChange.Reply());

        //EndpointIdentify
        RegisterPacketType(RdmCommands.Get, RdmParameters.EndpointIdentify, () => new EndpointIdentify.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.EndpointIdentify, () => new EndpointIdentify.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.EndpointIdentify, () => new EndpointIdentify.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.EndpointIdentify, () => new EndpointIdentify.SetReply());

        //EndpointToUniverse
        RegisterPacketType(RdmCommands.Get, RdmParameters.EndpointToUniverse, () => new EndpointToUniverse.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.EndpointToUniverse, () => new EndpointToUniverse.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.EndpointToUniverse, () => new EndpointToUniverse.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.EndpointToUniverse, () => new EndpointToUniverse.SetReply());

        //RdmTrafficEnable
        RegisterPacketType(RdmCommands.Get, RdmParameters.RdmTrafficEnable, () => new RdmTrafficEnable.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.RdmTrafficEnable, () => new BackgroundDiscovery.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.RdmTrafficEnable, () => new RdmTrafficEnable.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.RdmTrafficEnable, () => new RdmTrafficEnable.SetReply());

        //EndpointMode
        RegisterPacketType(RdmCommands.Get, RdmParameters.EndpointMode, () => new EndpointMode.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.EndpointMode, () => new EndpointMode.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.EndpointMode, () => new EndpointMode.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.EndpointMode, () => new EndpointMode.SetReply());

        //EndpointLabel
        RegisterPacketType(RdmCommands.Get, RdmParameters.EndpointLabel, () => new EndpointLabel.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.EndpointLabel, () => new EndpointLabel.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.EndpointLabel, () => new EndpointLabel.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.EndpointLabel, () => new EndpointLabel.SetReply());

        //DiscoveryState
        RegisterPacketType(RdmCommands.Get, RdmParameters.DiscoveryState, () => new DiscoveryState.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.DiscoveryState, () => new DiscoveryState.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.DiscoveryState, () => new DiscoveryState.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.DiscoveryState, () => new DiscoveryState.SetReply());

        //BackgroundDiscovery
        RegisterPacketType(RdmCommands.Get, RdmParameters.BackgroundDiscovery, () => new BackgroundDiscovery.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.BackgroundDiscovery, () => new BackgroundDiscovery.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.BackgroundDiscovery, () => new BackgroundDiscovery.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.BackgroundDiscovery, () => new BackgroundDiscovery.SetReply());

        //EndpointTiming
        RegisterPacketType(RdmCommands.Get, RdmParameters.EndpointTiming, () => new EndpointTiming.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.EndpointTiming, () => new EndpointTiming.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.EndpointTiming, () => new EndpointTiming.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.EndpointTiming, () => new EndpointTiming.SetReply());

        //EndpointTimingDescription
        RegisterPacketType(RdmCommands.Get, RdmParameters.EndpointTimingDescription, () => new EndpointTimingDescription.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.EndpointTimingDescription, () => new EndpointTimingDescription.GetReply());

        //EndpointDeviceListChange
        RegisterPacketType(RdmCommands.Get, RdmParameters.EndpointDeviceListChange, () => new EndpointDeviceListChange.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.EndpointDeviceListChange, () => new EndpointDeviceListChange.Reply());

        //Endpoint Devices
        RegisterPacketType(RdmCommands.Get, RdmParameters.EndpointDevices, () => new EndpointDevices.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.EndpointDevices, () => new EndpointDevices.Reply());

        //BindingControlFields
        //TcpCommsStatus
        //BackgroundQueuedStatusPolicy
        //BackgroundQueuedStatusPolicyDescription
        //BackgroundStatusType
        //QueuedStatusEndpointCollection
        //QueuedStatusUIDCollection
    }

    private void RegisterProductMessages()
    {
        //DeviceInfo
        RegisterPacketType(RdmCommands.Get, RdmParameters.DeviceInfo, () => new DeviceInfo.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.DeviceInfo, () => new DeviceInfo.GetReply());

        //ProductDetailIdList
        RegisterPacketType(RdmCommands.Get, RdmParameters.ProductDetailIdList, () => new ProductDetailIdList.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.ProductDetailIdList, () => new ProductDetailIdList.GetReply());

        //DeviceModelDescription
        RegisterPacketType(RdmCommands.Get, RdmParameters.DeviceModelDescription, () => new DeviceModelDescription.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.DeviceModelDescription, () => new DeviceModelDescription.GetReply());

        //ManufacturerLabel
        RegisterPacketType(RdmCommands.Get, RdmParameters.ManufacturerLabel, () => new ManufacturerLabel.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.ManufacturerLabel, () => new ManufacturerLabel.GetReply());

        //DeviceLabel
        RegisterPacketType(RdmCommands.Get, RdmParameters.DeviceLabel, () => new DeviceLabel.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.DeviceLabel, () => new DeviceLabel.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.DeviceLabel, () => new DeviceLabel.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.DeviceLabel, () => new DeviceLabel.SetReply());

        //FactoryDefaults
        RegisterPacketType(RdmCommands.Get, RdmParameters.FactoryDefaults, () => new FactoryDefaults.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.FactoryDefaults, () => new FactoryDefaults.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.FactoryDefaults, () => new FactoryDefaults.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.FactoryDefaults, () => new FactoryDefaults.SetReply());

        //LanguageCapabilities
        RegisterPacketType(RdmCommands.Get, RdmParameters.LanguageCapabilities, () => new LanguageCapabilities.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.LanguageCapabilities, () => new LanguageCapabilities.GetReply());

        //Language
        RegisterPacketType(RdmCommands.Get, RdmParameters.Language, () => new Language.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.Language, () => new Language.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.Language, () => new Language.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.Language, () => new Language.SetReply());

        //SoftwareVersionLabel
        RegisterPacketType(RdmCommands.Get, RdmParameters.SoftwareVersionLabel, () => new SoftwareVersionLabel.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.SoftwareVersionLabel, () => new SoftwareVersionLabel.GetReply());

        //BootSoftwareVersionId
        RegisterPacketType(RdmCommands.Get, RdmParameters.BootSoftwareVersionId, () => new BootSoftwareVersionId.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.BootSoftwareVersionId, () => new BootSoftwareVersionId.GetReply());

        //SoftwareVersionLabel
        RegisterPacketType(RdmCommands.Get, RdmParameters.BootSoftwareVersionLabel, () => new BootSoftwareVersionLabel.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.BootSoftwareVersionLabel, () => new BootSoftwareVersionLabel.GetReply());
    }

    private void RegisterPowerMessages()
    {
        //DeviceHours
        RegisterPacketType(RdmCommands.Get, RdmParameters.DeviceHours, () => new DeviceHours.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.DeviceHours, () => new DeviceHours.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.DeviceHours, () => new DeviceHours.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.DeviceHours, () => new DeviceHours.SetReply());

        //LampHours
        RegisterPacketType(RdmCommands.Get, RdmParameters.LampHours, () => new LampHours.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.LampHours, () => new LampHours.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.LampHours, () => new LampHours.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.LampHours, () => new LampHours.SetReply());

        //LampStrikes
        RegisterPacketType(RdmCommands.Get, RdmParameters.LampStrikes, () => new LampStrikes.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.LampStrikes, () => new LampStrikes.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.LampStrikes, () => new LampStrikes.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.LampStrikes, () => new LampStrikes.SetReply());

        //LampState
        RegisterPacketType(RdmCommands.Get, RdmParameters.LampState, () => new LampState.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.LampState, () => new LampState.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.LampState, () => new LampState.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.LampState, () => new LampState.SetReply());

        //LampOnMode
        RegisterPacketType(RdmCommands.Get, RdmParameters.LampOnMode, () => new LampOnMode.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.LampOnMode, () => new LampOnMode.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.LampOnMode, () => new LampOnMode.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.LampOnMode, () => new LampOnMode.SetReply());

        //DevicePowerCycles
        RegisterPacketType(RdmCommands.Get, RdmParameters.DevicePowerCycles, () => new DevicePowerCycles.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.DevicePowerCycles, () => new DevicePowerCycles.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.DevicePowerCycles, () => new DevicePowerCycles.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.DevicePowerCycles, () => new DevicePowerCycles.SetReply());

        //BurnIn
        RegisterPacketType(RdmCommands.Get, RdmParameters.BurnIn, () => new BurnIn.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.BurnIn, () => new BurnIn.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.BurnIn, () => new BurnIn.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.BurnIn, () => new BurnIn.SetReply());
    }

    private void RegisterDmxMessages()
    {
        //DmxPersonality
        RegisterPacketType(RdmCommands.Get, RdmParameters.DmxPersonality, () => new DmxPersonality.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.DmxPersonality, () => new DmxPersonality.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.DmxPersonality, () => new DmxPersonality.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.DmxPersonality, () => new DmxPersonality.SetReply());

        //DmxPersonalityDescription
        RegisterPacketType(RdmCommands.Get, RdmParameters.DmxPersonalityDescription, () => new DmxPersonalityDescription.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.DmxPersonalityDescription, () => new DmxPersonalityDescription.GetReply());

        //DmxStartAddress
        RegisterPacketType(RdmCommands.Get, RdmParameters.DmxStartAddress, () => new DmxStartAddress.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.DmxStartAddress, () => new DmxStartAddress.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.DmxStartAddress, () => new DmxStartAddress.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.DmxStartAddress, () => new DmxStartAddress.SetReply());

        //DmxBlockAddress
        RegisterPacketType(RdmCommands.Get, RdmParameters.DmxBlockAddress, () => new DmxBlockAddress.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.DmxBlockAddress, () => new DmxBlockAddress.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.DmxBlockAddress, () => new DmxBlockAddress.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.DmxBlockAddress, () => new DmxBlockAddress.SetReply());

        //SlotInfo
        RegisterPacketType(RdmCommands.Get, RdmParameters.SlotInfo, () => new SlotInfo.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.SlotInfo, () => new SlotInfo.GetReply());

        //SlotDescription
        RegisterPacketType(RdmCommands.Get, RdmParameters.SlotDescription, () => new SlotDescription.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.SlotDescription, () => new SlotDescription.GetReply());

        //DefaultSlotValue
        RegisterPacketType(RdmCommands.Get, RdmParameters.DefaultSlotValue, () => new DefaultSlotValue.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.DefaultSlotValue, () => new DefaultSlotValue.GetReply());

        //DmxStartupMode
        RegisterPacketType(RdmCommands.Get, RdmParameters.DmxStartupMode, () => new DmxStartupMode.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.DmxStartupMode, () => new DmxStartupMode.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.DmxStartupMode, () => new DmxStartupMode.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.DmxStartupMode, () => new DmxStartupMode.SetReply());
    }

    private void RegisterDimmerMessages()
    {
        //Curve
        RegisterPacketType(RdmCommands.Get, RdmParameters.Curve, () => new Curve.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.Curve, () => new Curve.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.Curve, () => new Curve.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.Curve, () => new Curve.SetReply());

        //CurveDescription
        RegisterPacketType(RdmCommands.Get, RdmParameters.CurveDescription, () => new CurveDescription.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.CurveDescription, () => new CurveDescription.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.CurveDescription, () => new CurveDescription.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.CurveDescription, () => new CurveDescription.SetReply());

        //DimmerInfo
        RegisterPacketType(RdmCommands.Get, RdmParameters.DimmerInfo, () => new DimmerInfo.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.DimmerInfo, () => new DimmerInfo.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.DimmerInfo, () => new DimmerInfo.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.DimmerInfo, () => new DimmerInfo.SetReply());

        //MaximumLevel
        RegisterPacketType(RdmCommands.Get, RdmParameters.MaximumLevel, () => new MaximumLevel.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.MaximumLevel, () => new MaximumLevel.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.MaximumLevel, () => new MaximumLevel.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.MaximumLevel, () => new MaximumLevel.SetReply());

        //MinimumLevel
        RegisterPacketType(RdmCommands.Get, RdmParameters.MinimumLevel, () => new MinimumLevel.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.MinimumLevel, () => new MinimumLevel.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.MinimumLevel, () => new MinimumLevel.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.MinimumLevel, () => new MinimumLevel.SetReply());

        //ModulationFrequency
        RegisterPacketType(RdmCommands.Get, RdmParameters.ModulationFrequency, () => new ModulationFrequency.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.ModulationFrequency, () => new ModulationFrequency.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.ModulationFrequency, () => new ModulationFrequency.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.ModulationFrequency, () => new ModulationFrequency.SetReply());

        //ModulationFrequencyDescription
        RegisterPacketType(RdmCommands.Get, RdmParameters.ModulationFrequencyDescription, () => new ModulationFrequencyDescription.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.ModulationFrequencyDescription, () => new ModulationFrequencyDescription.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.ModulationFrequencyDescription, () => new ModulationFrequencyDescription.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.ModulationFrequencyDescription, () => new ModulationFrequencyDescription.SetReply());

        //OutputResponseTime
        RegisterPacketType(RdmCommands.Get, RdmParameters.OutputResponseTime, () => new OutputResponseTime.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.OutputResponseTime, () => new OutputResponseTime.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.OutputResponseTime, () => new OutputResponseTime.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.OutputResponseTime, () => new OutputResponseTime.SetReply());

        //OutputResponseTimeDescription
        RegisterPacketType(RdmCommands.Get, RdmParameters.OutputResponseTimeDescription, () => new OutputResponseTimeDescription.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.OutputResponseTimeDescription, () => new OutputResponseTimeDescription.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.OutputResponseTimeDescription, () => new OutputResponseTimeDescription.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.OutputResponseTimeDescription, () => new OutputResponseTimeDescription.SetReply());
    }

    private void RegisterControlMessages()
    {
        //IdentifyDevice
        RegisterPacketType(RdmCommands.Get, RdmParameters.IdentifyDevice, () => new IdentifyDevice.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.IdentifyDevice, () => new IdentifyDevice.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.IdentifyDevice, () => new IdentifyDevice.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.IdentifyDevice, () => new IdentifyDevice.SetReply());

        //IdentifyMode
        RegisterPacketType(RdmCommands.Get, RdmParameters.IdentifyMode, () => new IdentifyMode.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.IdentifyMode, () => new IdentifyMode.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.IdentifyMode, () => new IdentifyMode.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.IdentifyMode, () => new IdentifyMode.SetReply());

        //ResetDevice
        RegisterPacketType(RdmCommands.Set, RdmParameters.ResetDevice, () => new ResetDevice.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.ResetDevice, () => new ResetDevice.SetReply());

        //PowerState
        RegisterPacketType(RdmCommands.Get, RdmParameters.PowerState, () => new PowerState.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.PowerState, () => new PowerState.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.PowerState, () => new PowerState.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.PowerState, () => new PowerState.SetReply());

        //PerformSelfTest
        RegisterPacketType(RdmCommands.Get, RdmParameters.PerformSelfTest, () => new PerformSelfTest.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.PerformSelfTest, () => new PerformSelfTest.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.PerformSelfTest, () => new PerformSelfTest.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.PerformSelfTest, () => new PerformSelfTest.SetReply());

        //PowerOnSelfTest
        RegisterPacketType(RdmCommands.Get, RdmParameters.PowerOnSelfTest, () => new PowerOnSelfTest.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.PowerOnSelfTest, () => new PowerOnSelfTest.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.PowerOnSelfTest, () => new PowerOnSelfTest.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.PowerOnSelfTest, () => new PowerOnSelfTest.SetReply());

        //SelfTestDescription
        RegisterPacketType(RdmCommands.Get, RdmParameters.SelfTestDescription, () => new SelfTestDescription.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.SelfTestDescription, () => new SelfTestDescription.GetReply());

        //CapturePreset
        RegisterPacketType(RdmCommands.Set, RdmParameters.CapturePreset, () => new CapturePreset.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.CapturePreset, () => new CapturePreset.SetReply());

        //PresetPlayback
        RegisterPacketType(RdmCommands.Get, RdmParameters.PresetPlayback, () => new PresetPlayback.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.PresetPlayback, () => new PresetPlayback.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.PresetPlayback, () => new PresetPlayback.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.PresetPlayback, () => new PresetPlayback.SetReply());

        //Preset Info
        RegisterPacketType(RdmCommands.Get, RdmParameters.PresetInfo, () => new PresetInfo.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.PresetInfo, () => new PresetInfo.GetReply());

        //Preset Status
        RegisterPacketType(RdmCommands.Get, RdmParameters.PresetStatus, () => new PresetStatus.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.PresetStatus, () => new PresetStatus.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.PresetStatus, () => new PresetStatus.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.PresetStatus, () => new PresetStatus.SetReply());

        //Preset Merge Mode
        RegisterPacketType(RdmCommands.Get, RdmParameters.PresetMergeMode, () => new PresetMergeMode.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.PresetMergeMode, () => new PresetMergeMode.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.PresetMergeMode, () => new PresetMergeMode.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.PresetMergeMode, () => new PresetMergeMode.SetReply());
    }

    private void RegisterConfigurationMessages()
    {
        //LockState
        RegisterPacketType(RdmCommands.Get, RdmParameters.LockState, () => new LockState.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.LockState, () => new LockState.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.LockState, () => new LockState.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.LockState, () => new LockState.SetReply());

        //LockPin
        RegisterPacketType(RdmCommands.Get, RdmParameters.LockPin, () => new LockPin.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.LockPin, () => new LockPin.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.LockPin, () => new LockPin.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.LockPin, () => new LockPin.SetReply());

        //LockStateDescription
        RegisterPacketType(RdmCommands.Get, RdmParameters.LockStateDescription, () => new LockStateDescription.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.LockStateDescription, () => new LockStateDescription.GetReply());

        //PanInvert
        RegisterPacketType(RdmCommands.Get, RdmParameters.PanInvert, () => new PanInvert.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.PanInvert, () => new PanInvert.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.PanInvert, () => new PanInvert.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.PanInvert, () => new PanInvert.SetReply());

        //TiltInvert
        RegisterPacketType(RdmCommands.Get, RdmParameters.TiltInvert, () => new TiltInvert.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.TiltInvert, () => new TiltInvert.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.TiltInvert, () => new TiltInvert.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.TiltInvert, () => new TiltInvert.SetReply());

        //PanTiltSwap
        RegisterPacketType(RdmCommands.Get, RdmParameters.PanTiltSwap, () => new PanTiltSwap.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.PanTiltSwap, () => new PanTiltSwap.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.PanTiltSwap, () => new PanTiltSwap.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.PanTiltSwap, () => new PanTiltSwap.SetReply());

        //RealTimeClock
        RegisterPacketType(RdmCommands.Get, RdmParameters.RealTimeClock, () => new RealTimeClock.Get());
        RegisterPacketType(RdmCommands.GetResponse, RdmParameters.RealTimeClock, () => new RealTimeClock.GetReply());
        RegisterPacketType(RdmCommands.Set, RdmParameters.RealTimeClock, () => new RealTimeClock.Set());
        RegisterPacketType(RdmCommands.SetResponse, RdmParameters.RealTimeClock, () => new RealTimeClock.SetReply());
    }

    

    private readonly Dictionary<PacketKey, Func<RdmPacket>> packetStore = new Dictionary<PacketKey, Func<RdmPacket>>();

    /// <summary>
    /// Registering RDM packet
    /// </summary>
    /// <param name="command"></param>
    /// <param name="parameter"></param>
    /// <param name="packetCreator"></param>
    /// <returns>true if success, false if packet is already registered</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public bool RegisterPacketType(RdmCommands command, RdmParameters parameter, Func<RdmPacket> packetCreator)
    {
        PacketKey key = new PacketKey
        {
            Command = command,
            Parameter = parameter
        };

        return packetStore.TryAdd(key, packetCreator);
        //    throw new InvalidOperationException(
        //        $"The packet {parameter.ToString()} is already registered for {command.ToString()}.");
    }
    
    public RdmPacket? Build(RdmBinaryReader data)
    {
        var messageLength = data.ReadByte();
        var destinationId = data.ReadUId();
        var sourceId = data.ReadUId();
        var transactionNumber = data.ReadByte();
        var portOrResponseType = data.ReadByte();
        var messageCount = data.ReadByte();
        var subDevice = data.ReadInt16();
        var command = (RdmCommands)data.ReadByte();
        var parameterId = (RdmParameters)data.ReadInt16();
        var parameterDataLength = data.ReadByte();

        PacketKey packetKey = new PacketKey(command, parameterId);
        
        if (IsErrorResponse(packetKey))
        {
            //Error Response Packets
            //return BuildErrorResponse(packetKey);
            
            return null;
        }

        if (!packetStore.TryGetValue(packetKey, out var packetCreator))
        {
            return null;
        }

        var packet = packetCreator();
        packet.MessageLength = messageLength;
        packet.DestinationId = destinationId;
        packet.SourceId = sourceId;
        packet.TransactionNumber = transactionNumber;
        packet.PortOrResponseType = portOrResponseType;
        packet.MessageCount = messageCount;
        packet.SubDevice = subDevice;
        packet.Command = command;
        packet.ParameterId = parameterId;
        packet.ParameterDataLength = parameterDataLength;
        
        packet.ParseData(data);
        
        return  packet;
    }
    
    

    public static bool IsErrorResponse(PacketKey packetKey)
    {
        return IsResponse(packetKey);
        //        && (RdmResponseTypes)header.PortOrResponseType switch
        // {
        //     RdmResponseTypes.Ack or RdmResponseTypes.AckOverflow => false,
        //     _ => true
        // };
    }

    public static bool IsResponse(PacketKey packetKey)
    {
        return packetKey.Command is RdmCommands.GetResponse or RdmCommands.SetResponse;
    }

    // public static RdmPacket? BuildErrorResponse(RdmHeader header)
    // {
    //     if (header.PortOrResponseType != 0)
    //     {
    //         switch ((RdmResponseTypes)header.PortOrResponseType)
    //         {
    //             case RdmResponseTypes.AckTimer:
    //                 return RdmPacket.Create(header, () => new RdmAckTimer());
    //             case RdmResponseTypes.NackReason:
    //                 return RdmPacket.Create(header, () => new RdmNack());
    //         }
    //     }
    //
    //     return null;
    // }

}
