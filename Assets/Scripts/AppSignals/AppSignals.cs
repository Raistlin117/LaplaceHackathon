using AppCore.UI.Screens;
using deVoid.Utils;

namespace AppSignals
{

    public class AppDataUpdatedSignal : ASignal
    {
    }

    public class OptionSelectedSignal : ASignal<OptionType>
    {
    }

    public class UserDataUpdatedSignal : ASignal
    {
    }

    public class OpenScreenSignal : ASignal<ScreenType, int>
    {
    }
}