using Codice.Client.BaseCommands.Merge.Xml;
using System.Collections.Generic;
using UnityEngine;


namespace Isostopy.PanelController
{

    /// <summary> Componente para cambiar entre una lista de paneles en la que solo uno de ellos esta activado al mismo tiempo. </summary>
    public class PanelController : MonoBehaviour
    {
        [Space]
        [SerializeField] protected List<Panel> panels = new();
        [SerializeField] protected string startPanel;


        // ----------------------------------------------------------------------------------

        private void Reset()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                panels.Add(new Panel { id = child.name, gameObject = child.gameObject });
            }

            if (transform.childCount == 0)
            {
                Debug.LogWarning("The panel controller works by expecting panels to be children of the object where the \"PanelController\" script is located. If you reset the \"Panel controller\" component, the found child panels will be added automatically. Panels do not need to carry any extra script.");
            }

        }


        // ----------------------------------------------------------------------------------

        private void Start()
        {
            if (panels.Count > 0)
                ShowPanel(startPanel);
        }

        /// <summary> Muestra el panel con el id indicado, desactivando el resto. </summary>
        public void ShowPanel(string targetPanel)
        {
            foreach (Panel panel in panels)
            {
                Debug.Log(panel);
                panel.SetActive(panel.id == targetPanel);
            }
        }

        /// <summary> Muestra el panel indicado, desactivando el resto. </summary>
        public void ShowPanel(GameObject targetPanel)
        {
            foreach (Panel panel in panels)
            {
                panel.SetActive(panel.gameObject == targetPanel);
            }
        }


        // ----------------------------------------------------------------------------------

        [System.Serializable]
        public class Panel
        {
            public string id = "";
            public GameObject gameObject = null;

            public void SetActive(bool value) => gameObject.SetActive(value);
        }
    }

}