import { Action, Reducer } from 'redux';
import * as actionTypes from '../actionCreators/actionTypes';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface BloodWorkListState {
    isLoading: boolean;
    pageIndex?: number;
    bloodWork: BloodWorkItem[];
}

export interface BloodWorkItem {
    id: string,
    dateCreated: string;
    examDate: string;
    resultsDate: string;
    description: string;
    hemoglobin: number;
    hematocrit: number;
    whiteBloodCellCountMCPMcL: number;
    redBloodCellCountMCPMcL: number;
}

export interface BloodWorkListResponse {
    result: BloodWorkItem[],
    status: number,
    title: string,
    errors: object[]
}


// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: BloodWorkListState = { bloodWork: [], isLoading: false };

export const reducer: Reducer<BloodWorkListState> = (state: BloodWorkListState | undefined, incomingAction: Action): BloodWorkListState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownBloodWorkAction;
    switch (action.type) {
        case actionTypes.RequestBloodWorkAction.type:
            return {
                pageIndex: action.pageIndex,
                bloodWork: state.bloodWork,
                isLoading: true
            };
        case actionTypes.ReceiveBloodWorkAction.type:
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            if (action.pageIndex === state.pageIndex) {
                return {
                    pageIndex: action.pageIndex,
                    bloodWork: action.bloodWork,
                    isLoading: false
                };
            }
            break;
    }

    return state;
};
