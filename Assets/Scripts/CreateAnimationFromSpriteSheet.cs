using UnityEngine;

public class CreateAnimationFromSpriteSheet : MonoBehaviour
{
    public Sprite[] spriteSheetFrames;
    public string animationName;

    private void Start()
    {
        // Create a new animation clip
        AnimationClip animationClip = new AnimationClip();
        animationClip.name = animationName;

        // Set the frame rate of the animation
        animationClip.frameRate = 30;

        // Create the animation curve for the sprite renderer
        AnimationCurve spriteCurve = new AnimationCurve();
        for (int i = 0; i < spriteSheetFrames.Length; i++)
        {
            spriteCurve.AddKey(i / (float)spriteSheetFrames.Length, i);
        }

        // Add the sprite curve to the animation clip
        animationClip.SetCurve("", typeof(SpriteRenderer), "m_Sprite", spriteCurve);

        // Save the animation clip to the project folder
        UnityEditor.AssetDatabase.CreateAsset(animationClip, "Assets/" + animationName + ".anim");
    }
}
