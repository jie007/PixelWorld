using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class RTTSpriteFull : MonoBehaviour {

	private SpriteRenderer spriteRenderer = null;
	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.material.renderQueue =2980; //这段代码非常重要！！！大家务必要加上，不然透明的渲染层级会出错
	}
}