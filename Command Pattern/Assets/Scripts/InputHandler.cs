using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    [SerializeField]
    private GameObject actor;

    private Animator animator;

    private Command keySpace, keyP, keyK, keyW;

    private List<Command> commands = new List<Command>();
    private bool isReplaying = false;
    private bool startReplay = false;
    private Coroutine replayCoroutine;


    // Start is called before the first frame update
    void Start() {
        animator = actor.GetComponent<Animator>();

        keySpace = new JumpCommand();
        keyP = new PunchCommand();
        keyK = new KickCommand();
        keyW = new MoveCommand();

        Camera.main.GetComponent<CameraFollow360>().player = actor.transform;
    }

    // Update is called once per frame
    void Update() {
        if (!isReplaying)
            InputHandle();

        ReplayCommands();

    }

    private void InputHandle() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            keySpace.Execute(animator);
            commands.Add(keySpace);
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            keyP.Execute(animator);
            commands.Add(keyP);
        }

        if (Input.GetKeyDown(KeyCode.K)) {
            keyK.Execute(animator);
            commands.Add(keyK);
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            keyW.Execute(animator);
            commands.Add(keyW);
        }

        if (Input.GetKeyDown(KeyCode.R))
            startReplay = true;

        if (Input.GetKeyDown(KeyCode.U))
            UndoCommand();
            
    }

    private void UndoCommand() {
        if(commands.Count > 0) {
            Command c = commands[commands.Count - 1];
            c.Execute(animator, true);
            commands.Remove(c);
        }
        
    }

    private void ReplayCommands() {

        if(startReplay && commands.Count > 0) {

            startReplay = false;
            if (replayCoroutine != null)
                StopCoroutine(replayCoroutine);

            replayCoroutine = StartCoroutine(ReplayCommandsCoroutine());

        }

    }

    private IEnumerator ReplayCommandsCoroutine() {

        isReplaying = true;
        int size = commands.Count;

        for(int i = 0; i < size; i++) {
            commands[i].Execute(animator);
            yield return new WaitForSeconds(1);
        }

        isReplaying = false;

    }
}
