using YG;

public class YGSaveSystem : ISaveSystem
{
    public void Save(SaveData data)
    {
        YandexGame.savesData += data;
        YandexGame.SaveProgress();
    }

    public SaveData Load()
    {
        return (SaveData)YandexGame.savesData;
    }
}
