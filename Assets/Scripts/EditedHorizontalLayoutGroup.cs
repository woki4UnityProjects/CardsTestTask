using DG.Tweening;
namespace UnityEngine.UI
{
    [AddComponentMenu("Layout/Edited Horizontal Layout Group")]
    public class EditedHorizontalLayoutGroup : HorizontalOrVerticalLayoutGroup
    {
        protected EditedHorizontalLayoutGroup()
        {}

        /// <summary>
        /// Called by the layout system. Also see ILayoutElement
        /// </summary>
        public override void CalculateLayoutInputHorizontal()
        {
            base.CalculateLayoutInputHorizontal();
            CalcAlongAxis(0, false);
        }

        /// <summary>
        /// Called by the layout system. Also see ILayoutElement
        /// </summary>
        public override void CalculateLayoutInputVertical()
        {
            //CalcAlongAxis(1, false);
        }

        /// <summary>
        /// Called by the layout system. Also see ILayoutElement
        /// </summary>
        public override void SetLayoutHorizontal()
        {
            SetChildrenAlongAxis(0, false);
        }

        /// <summary>
        /// Called by the layout system. Also see ILayoutElement
        /// </summary>
        public override void SetLayoutVertical()
        {
            Transform thisTransform = transform;
            int childCount = thisTransform.childCount;
            float heightDelta = 0.2f;
            float rotationDelta = 10f;
            int middle = childCount / 2;

            for (int i = 0; i < childCount; i++)
            {
                Vector3 newRotation = new Vector3(0, 0, rotationDelta * -(i - middle));
                transform.GetChild(i).DORotate(newRotation, 0.25f);

                RectTransform childRect = transform.GetChild(i).GetComponent<RectTransform>();
                float x = childRect.position.x;

                Vector3 newPosition = new Vector3(x, thisTransform.position.y - heightDelta * Mathf.Abs(i - middle), 0);
                childRect.DOMove(newPosition, 0.25f);
            }
        }
    }
}
