using Content.Client.Shuttles.UI;
using Content.Shared.Shuttles.BUIStates;
using JetBrains.Annotations;
using Robust.Client.GameObjects;
using Robust.Client.UserInterface;
using MassScannerWindow = Content.Client.Shuttles.UI.MassScannerWindow;

namespace Content.Client.Shuttles.BUI;

[UsedImplicitly]
public sealed class MassScannerBoundUserInterface : BoundUserInterface
{
    [ViewVariables]
    private MassScannerWindow? _window;

    public MassScannerBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey)
    {
    }

    protected override void Open()
    {
        base.Open();

        _window = this.CreateWindow<MassScannerWindow>();
        _window?.SetConsole(Owner);
    }

    protected override void UpdateState(BoundUserInterfaceState state)
    {
        base.UpdateState(state);
        if (state is not NavBoundUserInterfaceState cState)
            return;

        _window?.UpdateState(cState.State);
    }
}
