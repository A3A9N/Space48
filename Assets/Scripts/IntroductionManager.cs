using System.Collections;
using UnityEngine;

public class IntroductionManager : MonoBehaviour
{
    [SerializeField] private MessageSystem messageSystem;

    void Start()
    {
        StartCoroutine(ShowIntroduction());
    }

    private IEnumerator ShowIntroduction()
    {
        messageSystem.ShowMessage("Welcome to Space 4 8. \nMove your ship with the arrows or WASD. \nShoot with SPACE. \nGather pickups and cycle with 'Left CTR'. \nUse pickups with 'E'.", 5f);
        yield return new WaitForSeconds(5f);
    }
}
