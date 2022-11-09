using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip_T1 : MonoBehaviour {


    private Text tooltipText;


	void Start () {
        tooltipText = GetComponentInChildren<Text>();
        gameObject.SetActive(false);
	}

    public void GenerateTooltip(Item_T1 item_t1)
    {
        string statText = "";

        if(item_t1.stats.Count > 0)
        {
            foreach(var stat in item_t1.stats)
            {
                statText += stat.Key.ToString() + ": " + stat.Value + "\n";
            }
        }

        string tooltip = string.Format("<b>{0}</b> \n {1} \n\n {2}", item_t1.title, item_t1.description, statText);
        tooltipText.text = tooltip;
        gameObject.SetActive(true);
    }
}
