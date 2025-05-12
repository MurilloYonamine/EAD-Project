using UnityEngine;

public class MenuController : MonoBehaviour
{
    public CanvasGroup MenuDoJogo;
    public CanvasGroup MenuIncial;

    private void Start()
    {
        StartMenu();
    }

    //Button
    public void Iniciar(){GameMenu();}
    public void QUitButton() { Application.Quit(); }
    public void GameMenu()
    {

        Hide(MenuIncial);
        Show(MenuDoJogo);
    }
    public void StartMenu()
    {
        Hide(MenuDoJogo);
        Show(MenuIncial);
    }

    public void Hide(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0; //Totalmente vazio, indica que a UI vai ficar com a opacidade no 0
        canvasGroup.blocksRaycasts = false; // O colisor do objeto não fica tela do jogo,n]ao atrapalhando outros cliques
        canvasGroup.interactable = false; //O objeto não é interagivel
    }
    public void Show(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1; //Mostra o UI
        canvasGroup.blocksRaycasts = true; //Colisor fica ativo
        canvasGroup.interactable = true; // è interagivel
    }
}
