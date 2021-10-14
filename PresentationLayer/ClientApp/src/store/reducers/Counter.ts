import { Action, Reducer } from 'redux';

import * as actionTypes from '../actions/actionTypes';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface CounterState {
    count: number;
}


// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

export const reducer: Reducer<CounterState> = (state: CounterState | undefined, incomingAction: Action): CounterState => {
    if (state === undefined) {
        return { count: 0 };
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
        case actionTypes.INCREMENT_COUNT:
            return { count: state.count + 1 };
        case actionTypes.DECREMENT_COUNT:
            return { count: state.count - 1 };
        default:
            return state;
    }
};
