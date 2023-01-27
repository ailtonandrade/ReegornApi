using AuthApi.Data;
using ReegornApi;

namespace AuthApi.Resources
{
    public class EnvironmentObjects
    {
        private static string prefixCollectableActive = "COL_A";
        private static string prefixCollectablePassive = "COL_P";
        private static string prefixCollectableFixed = "COL_F";
        private static string prefixUncollectable = "COL_U";
        private static int initialCount = 1;
        public static List<ObjectDataModel> data = new List<ObjectDataModel>() {

            //Cube Purple
            new ObjectDataModel() { id = genId(prefixCollectablePassive), hp = 4000, local = "LIMBO", name = "Cube Purple", positionX = 40f, positionY = 10.72f, positionZ = 0.3245959f, rotation = 0f, world = "ZERO" },
            new ObjectDataModel() { id = genId(prefixCollectablePassive), hp = 4000, local = "LIMBO", name = "Cube Purple", positionX = 35f, positionY = 10.72f, positionZ = 0.3245959f, rotation = 0f, world = "ZERO" },
            new ObjectDataModel() { id = genId(prefixCollectablePassive), hp = 4000, local = "LIMBO", name = "Cube Purple", positionX = 30f, positionY = 10.72f, positionZ = 0.3245959f, rotation = 0f, world = "ZERO" },
            new ObjectDataModel() { id = genId(prefixCollectablePassive), hp = 4000, local = "LIMBO", name = "Cube Purple", positionX = 25f, positionY = 10.72f, positionZ = 0.3245959f, rotation = 0f, world = "ZERO" },
            new ObjectDataModel() { id = genId(prefixCollectablePassive), hp = 4000, local = "LIMBO", name = "Cube Purple", positionX = 20f, positionY = 10.72f, positionZ = 0.3245959f, rotation = 0f, world = "ZERO" },
            new ObjectDataModel() { id = genId(prefixCollectablePassive), hp = 4000, local = "LIMBO", name = "Cube Purple", positionX = 15f, positionY = 10.72f, positionZ = 0.3245959f, rotation = 0f, world = "ZERO" },
            new ObjectDataModel() { id = genId(prefixCollectablePassive), hp = 4000, local = "LIMBO", name = "Cube Purple", positionX = 10f, positionY = 10.72f, positionZ = 0.3245959f, rotation = 0f, world = "ZERO" },
        
            //Cube Orange
            new ObjectDataModel() { id = genId(prefixCollectablePassive), hp = 1000, local = "LIMBO", name = "Cube Orange", positionX = 50f, positionY = 10.72f, positionZ = 0.3245959f, rotation = 0f, world = "ZERO" },
            new ObjectDataModel() { id = genId(prefixCollectablePassive), hp = 1000, local = "LIMBO", name = "Cube Orange", positionX = 55f, positionY = 10.72f, positionZ = 0.3245959f, rotation = 0f, world = "ZERO" },
            new ObjectDataModel() { id = genId(prefixCollectablePassive), hp = 1000, local = "LIMBO", name = "Cube Orange", positionX = 60f, positionY = 10.72f, positionZ = 0.3245959f, rotation = 0f, world = "ZERO" },
            new ObjectDataModel() { id = genId(prefixCollectablePassive), hp = 1000, local = "LIMBO", name = "Cube Orange", positionX = 10f, positionY = 10.72f, positionZ = 0.3245959f, rotation = 0f, world = "ZERO" }

        };

        private static string genId(string prefix)
        {
            return prefix + "_" + counter();
        }
        private static int counter()
        {
            return initialCount++;
        }

    }

}
