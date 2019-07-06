/* vim: set ts=4 sts=4 sw=4 expandtab: */
using UnityEngine;

public class TrackObjectBehaviour : BaseBehaviour {

    public override bool IsActive() { return true; }
    public override bool InterruptChain() { return false; }
    public override void Iterate() {} 

}
