using System;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() :
            base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length == 1 && text[0].ToLower() == "look")
            {
                return p.Location.FullDescription;
            }
            else if (text.Length >= 3 && text[0].ToLower() == "look" && text[1].ToLower() == "at")
            {
                IHaveInventory container;
                string itemId;
                string error = "Error in Look Output";

                switch (text.Length)
                {
                    case 3:
                        container = p;
                        itemId = text[2];
                        break;

                    case 5:
                        container = FetchContainer(p, text[4]);
                        if (container == null)
                            return "Could not find " + text[4];
                        itemId = text[2];
                        break;

                    default:
                        return error;
                }

                return LookAtIn(itemId, container);
            }
            else
            {
                return "What do you want to look at?";
            }
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) != null)
                return container.Locate(thingId).FullDescription;

            return (thingId + " Couldn't be found");
        }
    }
}
