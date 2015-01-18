#pragma strict

var targetObject : GameObject;
private var lineRenderer : LineRenderer;

function Start() {
	lineRenderer = GetComponent(LineRenderer);
}

function Update () {
	lineRenderer.SetPosition(0,this.transform.localPosition);
	
	for(var i:int=1;i<4;i++)
	{
		var pos = Vector3.Lerp(this.transform.localPosition,targetObject.transform.localPosition,i/4.0f);
		
		pos.x += Random.Range(-0.4f,0.4f);
		pos.y += Random.Range(-0.4f,0.4f);
		
		lineRenderer.SetPosition(i,pos);
	}
	
	lineRenderer.SetPosition(4,targetObject.transform.localPosition);
}