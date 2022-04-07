using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Purchasing;


public class BtnIAP : MonoBehaviour
{

    public Text SuccessText;
    public enum purchaseType
    {
        Coin1125,
        Coin2250,
        Coin4500,
        Coin9000,
        AdsRemover
    }
    public purchaseType pType;

    public void onPurchaseComplete(Product product)
    {
        GameManager GM = FindObjectOfType<GameManager>();
        ShopManager show = FindObjectOfType<ShopManager>();
        StartCoroutine(shownSuccessText("SUCCESS"));
        switch (pType)
        {
            case purchaseType.Coin1125:
                GM.Coins += 1125;
                GM.saveCoins();
                if (show != null)
                    show.UpdateCoin();
                break;
            case purchaseType.Coin2250:
                GM.Coins += 2250;
                GM.saveCoins();
                if (show != null)
                    show.UpdateCoin();
                break;
            case purchaseType.Coin4500:
                GM.Coins += 4500;
                GM.saveCoins();
                if (show != null)
                    show.UpdateCoin();
                break;
            case purchaseType.Coin9000:
                GM.Coins += 9000;
                GM.saveCoins();
                if (show != null)
                    show.UpdateCoin();
                break;
            case purchaseType.AdsRemover:
                GM.ADS = 1;
                GM.saveADS();
                if (show != null)
                    show.UpdateCoin();
                break;
        }
        Debug.Log("Purchase of Product " + product.definition.id + " Successful");

    }

    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        StartCoroutine(shownSuccessText("FAILED"));
        Debug.Log("Purchase of Product " + product.definition.id + " failed due to " + reason);
    }


    IEnumerator shownSuccessText(string set)
    {
        SuccessText.text = "" + set + "";
        SuccessText.DOColor(new Vector4(1, 1, 1, 1), 0.5f);
        yield return new WaitForSeconds(2.5f);
        SuccessText.DOColor(new Vector4(0, 0, 0, 0), 0.5f);
    }


}
