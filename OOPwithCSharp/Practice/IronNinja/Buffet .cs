

class Buffet 
{


    public List<IConsumable> Menu;

    public Buffet()
    {
        Menu = new List<IConsumable>();
    }

    public void AddToMenu(IConsumable consumable)
    {
        Menu.Add(consumable);
    }

    
}
