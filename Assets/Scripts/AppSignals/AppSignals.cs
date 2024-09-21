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
}