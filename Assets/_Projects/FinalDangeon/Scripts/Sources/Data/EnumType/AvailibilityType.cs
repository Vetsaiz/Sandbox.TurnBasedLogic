
namespace MetaLogic.Data
{
    public enum AvailibilityType
    {
        None = 0,
        VisibleAndEnable = 1,
        VisibleAndEnableForActivation = 2,
        NoVisible = 3,
        VisibleNoEnable = 4,
        NoVisibleEnable = 5
    }

    public enum InteractiveType
    {
        None = 0,
        VisibleActivate = 1,
        VisibleNoActivate = 2,
        NoVisibleActivate = 3,
        NoVisibleNoActivate = 4,
    }
}
