namespace ReegornApi.Data
{
    public class GameObjectsData
    {
        public string gameObjectsData { get; set; }
        public string characterInfos { get; set; }
        public GameObjectsData()
        {
            characterInfos = @"{'CharacterInformations':
                                    {'Id':'0',
                                     'Name':'Tom',
                                     'Hp':'2316516',
                                     'Stamina':'200',
                                     'InternalId':'1E65E1E65'
                                    }
                                }";
            gameObjectsData = @"{
                                    'gameObjEnvData':[
                                                    {'Id':'1','Name':'CubeOrange','Hp':'100','InternalId':'ASD1A64'},
                                                    {'Id':'2','Name':'CubePurple','Hp':'100','InternalId':'ASD52165'}
                                    ]
                                }";
        }
    }
}

