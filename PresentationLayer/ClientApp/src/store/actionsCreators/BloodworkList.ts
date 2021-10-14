import { AppThunkAction } from '..';
import { BloodWorkListResponse } from '../reducers/BloodWork';
import * as actionTypes from './actionTypes';


// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const requestBloodWork: (pageIndex: number): AppThunkAction<actionTypes.KnownBloodWorkListAction> => (dispatch, getState) => {
    // Only load data if it's something we don't already have (and are not already loading)
    const appState = getState();
    if (appState && appState.bloodWork && pageIndex !== appState.bloodWork.pageIndex) {
        fetch(`api/bloodwork?page=${pageIndex}`)
            .then(response => response.json() as Promise<BloodWorkListResponse>)
            .then(data => {
                dispatch({ type: actionTypes.RequestBloodWorListkAction.type, pageIndex: pageIndex, bloodWork: data.result });
            });

        dispatch({ type: actionTypes.RequestBloodWorListkAction.type, pageIndex: pageIndex });
    }
};
