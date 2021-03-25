using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class UnitImpactAnimFrameExecutor : ImpactExecutor<IUnitImpactAnimFrame>
    {
        private readonly ApplyChangeLogic _logic;
        private readonly FormulaLogic _formula;

        public UnitImpactAnimFrameExecutor(ApplyChangeLogic logic, FormulaLogic formula)
        {
            _formula = formula;
            _logic = logic;
        }

        public override void Execute(IUnitImpactAnimFrame data)
        {
            _logic.BatchAbilityInFrame();
            var frameData = new FrameAbility {FamiliarAnimStart = data.FamiliarAnimStart, UnityId = data.UnityObjectId };
            if (float.TryParse(data.ShellDuration, out var value))
            {
                frameData.ShellDuration = value;
            }
            frameData.Time = (float)_formula.Calculate(data.TimeFormula);
            _logic.Data = frameData;
        }

        public override ImpactType Id => ImpactType.ImpAnimFrame;
    }
}
