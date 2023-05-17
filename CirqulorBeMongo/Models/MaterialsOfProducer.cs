using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CirqulorBeMongo.Models
{
   
    public class MaterialsOfProducer 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        
        
        public Properties? Properties { get; set; }
        public string? Notes { get; set; }
        public string? photoUrl { get; set; }   
       // name of material
        [BsonRepresentation(BsonType.ObjectId)]
        public string? NameOfMaterial { get; set; }

        public string? NameOfMaterialName { get; set; }

        // user
        //[BsonRepresentation(BsonType.ObjectId)]
        public Guid? Producer { get; set; }
     
        public string? ProducerName { get; set; }


    }

    public class PhysicalProperties
    {

        public string? Density { get; set; }

        public string? Thickness { get; set; }

   
        public string? MoistureAbsorptionatEquilibrium { get; set; }


        public string? AdditiveLoading { get; set; }

        public string? MoistureVaporTransmission { get; set; }

        public string? WaterVaporTransmission { get; set; }

        public string? OxygenTransmission { get; set; }

        public string? NitrogenTransmission { get; set; }
        public string? CarbonDioxideTransmission { get; set; }

        public string? MaximumMoistureContent { get; set; }
        public string? LinearMoldShrinkage { get; set; }
        public string? LinearMoldShrinkageTransverse { get; set; }

        public string? MeltFlow { get; set; }


    }
    public class ThermalProperties
    {
        public string? CTElinear { get; set; }
        public string? ThermalConductivity { get; set; }
        public string? MeltingPoint { get; set; }
        public string? MaximumServiceTemperatureAir { get; set; }

        public string? DeflectionTemperatureAt66psi { get; set; }

        public string? DeflectionTemperatureAt264psi { get; set; }
        public string? VicatSofteningPoint { get; set; }
        public string? GlassTransitionTempTg { get; set; }  

        public string? FlammabilityUL94 { get; set; }



        // Add other properties
    }
    public class DescriptiveProperties
    {
        public string? FlameSupportResistance { get; set; }
        public string? ResistanceToHydrocarbons { get; set; }
        public string? ResistanceToOil { get; set; }
        public string? StandartWidth { get; set; }

    }
    public class MechanicalProperties
    {
        public string? HardnessRockwellR { get; set; }
        public string? BallIndentationHardness { get; set; }
        public string? TensileStrengthUltimate { get; set; }
        public string? FilmTensileStrengthAtYieldMD { get; set; }
        public string? FlameSupportResistance { get; set; }
        public string? FilmTensileStrengthAtYieldTD { get; set; }
        public string? TensileStrengthYield { get; set; }
        public string? FilmElongationAtBreakMD { get; set; }
        public string? FilmElongationAtBreakTD { get; set; }
        public string? ElongationAtBreak { get; set; }
        public string? ElongationAtYield { get; set; }
        public string? ModulusOfElasticity { get; set; }
        public string? Tenacity { get; set; }
        public string? FlexuralYieldStrength { get; set; }
        public string? FlexuralModulus { get; set; }
        public string? FlexuralStrainAtBreak { get; set; }
        public string? SecantModulus { get; set; }
        public string? SecantModulusMD { get; set; }
        public string? SecantModulusTD { get; set; }
        public string? IzodImpactNotched { get; set; }
        public string? IzodImpactUnnotched { get; set; }
        public string? IzodImpactNotchedISO { get; set; }
        public string? IzodImpactUnnotchedISO { get; set; }
        public string? CharpyImpactUnnotched { get; set; }
        public string? CharpyImpactNotched { get; set; }
        public string? CoefficientOfFriction { get; set; }
        public string? CoefficientOfFrictionStatic { get; set; }
        public string? TearStrength { get; set; }
        public string? ElmendorfTearStrengthMD { get; set; }
        public string? ElmendorfTearStrengthTD { get; set; }
        public string? DartDropTotalEnergy { get; set; }
        public string? DartDropTest { get; set; }
        public string? FilmTensileStrengthAtBreakMD { get; set; }
        public string? FilmTensileStrengthAtBreakTD { get; set; }
        public string? HardnessShoreA { get; set; }
        public string? HardnessShoreD { get; set; }
    }

    public class OpticalProperties
    {
       public string? Haze { get; set; }
        public string? Gloss { get; set; }
        public string? TransmissionVisible { get; set; }
    }

    public class ProcessingProperties
    {
        public string? ProcessingTemperature { get; set; }
        public string? NozzleTemperature { get; set; }
        public string? AdapterTemperature { get; set; }
        public string? DieTemperature { get; set; }
        public string? MeltTemperature { get; set; }
        public string? MoldTemperature { get; set; }
        public string? DryingTemperature { get; set; }
        public string? MoistureContent { get; set; }
        public string? DewPoint { get; set; }
        public string? DryingAirFlowRate { get; set; }
        public string? InjectionPressure { get; set; }
    }

    public class ElectricalProperties
    {
        public string? ElectricalResistivity { get; set; }
        public string? SurfaceResistance { get; set; }
        public string? DielectricConstant { get; set; }
        public string? DissipationFactor { get; set; }
    }
    public class Properties
    {
        public PhysicalProperties? PhysicalProperties { get; set; }

        public ThermalProperties? ThermalProperties { get; set; }

        public DescriptiveProperties? DescriptiveProperties { get; set; }

        public MechanicalProperties? MechanicalProperties { get; set; }
        public  OpticalProperties? OpticalProperties { get; set; }

        public ProcessingProperties? ProcessingProperties { get; set; }

        public  ElectricalProperties? ElectricalProperties { get; set; }
    }
}
