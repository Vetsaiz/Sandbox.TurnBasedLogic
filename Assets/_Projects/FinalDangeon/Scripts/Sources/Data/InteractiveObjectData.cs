using MetaLogic.Logic.Static;

namespace MetaLogic.Data
{
    public class InteractiveObjectData
    {
        public AvailibilityType Availibility;
        public bool Backlight;
        public bool MinimapVisability;
        public bool Impassable;
        public bool Danger;

        public override string ToString()
        {
            return $"availibility:{Availibility}|backlight:{Backlight}|minimap_visability:{MinimapVisability}|impassable:{Impassable}|danger:{Danger}";
        }

        public static InteractiveObjectData Create(IImpactInteractiveObject obj)
        {
            return new InteractiveObjectData
            {
                Availibility = obj.Availibility,
                Backlight = obj.Backlight,
                Danger = obj.Danger,
                Impassable = obj.Impassable,
                MinimapVisability = obj.MinimapVisability
            };
        }

        public static InteractiveObjectData Create(IInteractiveObject obj)
        {
            return new InteractiveObjectData
            {
                Availibility = obj.Availibility,
                Backlight = obj.Backlight,
                Danger = obj.Danger,
                Impassable = obj.Impassable,
                MinimapVisability = obj.MinimapVisability
            };
        }
    }
}
