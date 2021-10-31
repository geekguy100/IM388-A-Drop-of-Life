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
        [SerializeField] private GameObject wateredModel;

        public string GetDisplayInfo()
        {
            return "Press 'E' to water the flower.";
        }

        public override string ToString()
        {
            return gameObject.name;
        }

        public void Interact(Interactor interactor)
        {
            WaterFlower();
        }

        /// <summary>
        /// Waters the flower by swapping out the models.
        /// </summary>
        private void WaterFlower()
        {
            // Destroying the current model and spawning in the new one.
            Destroy(transform.GetChild(0).gameObject);
            Instantiate(wateredModel, transform);

            // Putting the flower on the default layer to prevent
            // any future interactions.
            gameObject.layer = 0;
            gameObject.name = "Flower_Watered";
            
            // TODO: Play SFX.
        }
    }
}