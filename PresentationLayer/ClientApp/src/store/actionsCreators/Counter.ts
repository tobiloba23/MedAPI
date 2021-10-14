// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    increment: () => ({ type: 'INCREMENT_COUNT' } as IncrementCountAction),
    decrement: () => ({ type: 'DECREMENT_COUNT' } as DecrementCountAction)
};