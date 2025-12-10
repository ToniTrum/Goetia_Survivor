using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

static class AnimationStateMachine
{
    static void CreateStateMachine()
    {
        var controllerPath = AssetDatabase.GenerateUniqueAssetPath("Assets/_project/Player/Animation/PlayerAnimationStateMachine.controller");
        var controller = AnimatorController.CreateAnimatorControllerAtPath(controllerPath);
        
        var stateMachine = controller.layers[0].stateMachine;
        
        var idleState = stateMachine.AddState("Idle", new Vector2(100, 100));
        var walkState = stateMachine.AddState("Walk", new Vector2(100, 150));
        var dashState = stateMachine.AddState("Dash", new Vector2(150, 100));
        
        controller.AddParameter("Speed", AnimatorControllerParameterType.Float);

        var walkToDash = walkState.AddTransition(dashState);
        var dashToWalk = dashState.AddTransition(walkState);

        var idleToWalk = idleState.AddTransition(walkState);
        idleToWalk.AddCondition(AnimatorConditionMode.Greater, 0.1f, "Speed");
        var walkToIdle = walkState.AddTransition(idleState);
        idleToWalk.AddCondition(AnimatorConditionMode.Less, 0.1f, "Speed");
        
        var idleToDash = idleState.AddTransition(dashState);
        var dashToIdle = dashState.AddTransition(walkState);
    }
}