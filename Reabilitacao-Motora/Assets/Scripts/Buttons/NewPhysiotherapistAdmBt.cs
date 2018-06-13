using UnityEngine;
using UnityEngine.UI;

public class NewPhysiotherapistAdmBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticNewPhysiotherapistAdm();});
	}
}