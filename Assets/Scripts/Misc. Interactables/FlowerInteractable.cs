/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 10/18/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    public class FlowerInteractable : MonoBehaviour, IInteractableDisplay
    {
        public string GetDisplayInfo()
        {
            return "Press 'E' to water the flower.";
        }

        public string ToString()
        {
            return gameObject.name;
        }

        public void Interact(Interactor interactor)
        {
            interactor.UnassignInteractable();
            Destroy(gameObject);
        }
    }
}