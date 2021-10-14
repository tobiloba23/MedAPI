import { BloodWorkItem } from "../reducers/BloodWork";

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

export interface RequestBloodWorListkAction {
    type: 'REQUEST_BLOOD_WORK';
    pageIndex: number;
}

export interface ReceiveBloodWorListkAction {
    type: 'RECEIVE_BLOOD_WORK';
    pageIndex: number;
    bloodWork: BloodWorkItem[];
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
export type KnownBloodWorkAction = RequestBloodWorListkAction | ReceiveBloodWorListkAction;




// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.
// Use @typeName and isActionType for type detection that works even after serialization/deserialization.

export interface IncrementCountAction { type: 'INCREMENT_COUNT' }
export interface DecrementCountAction { type: 'DECREMENT_COUNT' }

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
export type KnownIncrementAction = IncrementCountAction | DecrementCountAction;



