namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения

        public int level = 1;
        public float target = 1000;
        public float capital = 100;
        public float deposit = 100;
        public float divident = 0;
        public bool[] lockedDividents = new bool[25];
        public bool[] openRealtyAndBusiness = new bool[25];
        public float[] sumRealtyAndBusiness = new float[25];
        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            openLevels[1] = true;
        }

        public static SavesYG operator+(SavesYG savesYG, SaveData saveData)
        {
            savesYG.level=saveData.level;
            savesYG.target=saveData.target;
            savesYG.capital=saveData.capital;
            savesYG.deposit=saveData.deposit;
            savesYG.divident=saveData.divident;
            for (int i = 0; i < savesYG.lockedDividents.Length; i++)
            {
                savesYG.lockedDividents[i] = saveData.lockedDividents[i];
            }
            for (int i = 0; i < savesYG.openRealtyAndBusiness.Length; i++)
            {
                savesYG.openRealtyAndBusiness[i] = saveData.openRealtyAndBusiness[i];
            }
            for (int i = 0; i < savesYG.sumRealtyAndBusiness.Length; i++)
            {
                savesYG.sumRealtyAndBusiness[i] = saveData.sumRealtyAndBusiness[i];
            }
            return savesYG;
        }
    }
}
