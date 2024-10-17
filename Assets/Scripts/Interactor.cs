using UnityEngine;

public class Interactor : MonoBehaviour
{
    public Interaction Interaction { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Interaction interaction))
        {
            if (Interaction != null)
            {
                Interaction.SetHighlight(false);
            }
            Interaction = interaction;
            Interaction.SetHighlight(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Interaction?.SetHighlight(false);
        Interaction = null;
    }
}