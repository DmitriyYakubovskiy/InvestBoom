using UnityEngine;
using YG;

public class Underwork : MonoBehaviour
{
    [SerializeField] private Money money;
    [SerializeField] private Capital capital;
    private const int bonusId = 1;

    private void AddMoney(int id)
    {
        if (id != bonusId) return;

        float bonusMoney = Mathf.Ceil(capital.GetCapital() / 5f);

        money.AddCapitalUpdate(bonusMoney);
        money.AddDepositUpdate(bonusMoney);
    }

    public void ButtonClick()
    {
        YGAdsProvider.ShowRewardedAD(bonusId);
    }

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += AddMoney;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= AddMoney;
    }
}
