using System.Collections.Generic;

public class SW_BuildingComponent : GameComponent<SW_MiniGame>
{
    public List<SW_BuildingCell> GetCells()
    {
        return MiniGame.FieldComponent.Field.GetCellsByType<SW_BuildingCell>();
    }
}
