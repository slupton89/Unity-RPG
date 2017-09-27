﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour {
    public static ItemDatabase Instance { get; set; }
    private List<Item> Items { get; set; }

	void Awake () {
		if(Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
        BuildDatabase();
	}
	
    private void BuildDatabase() {
        Items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/Items").ToString());
    }

    public Item GetItem(string itemSlug) {
        foreach (Item item in Items) {
            if (item.ObjectSlug == itemSlug) {
                return item;
            }                       
        }
        Debug.LogWarning("Couldn't find item: " + itemSlug);
        return null;
    }

}
